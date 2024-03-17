using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace YourNamespace.Controllers
{
    public class FileController : Controller
    {
        // GET: /File/DownloadFile
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        // POST: /File/DownloadFile
        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(fileName))
            {
                ModelState.AddModelError("", "Будь ласка, заповніть всі поля");
                return View();
            }

            string fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            var bytes = Encoding.UTF8.GetBytes(fileContent);

            HttpContext.Response.ContentType = "text/plain";
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName + ".txt");
            return File(bytes, "text/plain", fileName + ".txt");
        }
    }
}
