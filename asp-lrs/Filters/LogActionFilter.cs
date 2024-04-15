using Microsoft.AspNetCore.Mvc.Filters;

namespace asp_lrs.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.Controller.GetType().Name;
            string actionName = filterContext.RouteData.Values["action"].ToString(); // Отримуємо ім'я дії з RouteData
            string logMessage = $"{DateTime.Now} - Controller: {controllerName}, Action: {actionName}";

            // Шлях до файлу журналу
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Logs");
            string logFilePath = Path.Combine(logDirectory, "action_log.txt");

            // Перевіряємо, чи існує директорія, і якщо ні - створюємо її
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Записуємо у файл
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(logMessage);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}

