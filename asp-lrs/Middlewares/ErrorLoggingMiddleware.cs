using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace asp_lrs.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;

        public ErrorLoggingMiddleware(RequestDelegate next, string logFilePath)
        {
            _next = next;
            _logFilePath = logFilePath;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void LogError(Exception ex)
        {
            string errorMessage = $"[{DateTime.UtcNow}] {ex.ToString()}\n";

            // Перевірка наявності файлу та створення, якщо він не існує
            if (!File.Exists(_logFilePath))
            {
                using (FileStream fs = File.Create(_logFilePath))
                {
                    // Пустий блок для закриття потоку після створення файлу
                }
            }

            // Запис повідомлення про помилку у файл
            File.AppendAllText(_logFilePath, errorMessage);
        }
    }

    public static class ErrorLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLoggingMiddleware(this IApplicationBuilder builder, string logFilePath)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>(logFilePath);
        }
    }
}
