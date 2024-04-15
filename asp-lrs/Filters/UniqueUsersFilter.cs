using Microsoft.AspNetCore.Mvc.Filters;


namespace asp_lrs.Filters
{
    public class UniqueUsersFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var response = httpContext.Response;

            var uniqueUserCookie = httpContext.Request.Cookies["UniqueUser"];

            if (uniqueUserCookie == null)
            {
                uniqueUserCookie = Guid.NewGuid().ToString();
                response.Cookies.Append("UniqueUser", uniqueUserCookie, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                });

                UpdateUniqueUsersCount(httpContext);
            }
        }

        private void UpdateUniqueUsersCount(HttpContext httpContext)
        {
            var uniqueUsersCount = httpContext.Session.GetInt32("UniqueUsersCount") ?? 0;
            uniqueUsersCount++;
            httpContext.Session.SetInt32("UniqueUsersCount", uniqueUsersCount);

            string logFilePath = Path.Combine(httpContext.Request.PathBase, "Logs", "unique_users_log.txt");

            using (StreamWriter writer = new StreamWriter(logFilePath, false))
            {
                writer.WriteLine($"Unique Users Count: {uniqueUsersCount}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Not needed for this example
        }
    }
}
