using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_lrs.Controllers
{
	public class DataController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public IActionResult ThrowException()
        {
            string message = "This is an exception thrown by clicking a button.";
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                LogError(ex, message);
                throw; // Якщо потрібно, ви можете викинути виняток далі
            }
        }
        private void LogError(Exception ex, string message)
        {
            string errorMessage = $"[{DateTime.UtcNow}] {message}\n{ex.ToString()}\n";
        }
        public IActionResult StoreData(string value, DateTime expirationDate)
		{
			Response.Cookies.Append("storedData", value, new CookieOptions
			{
				Expires = expirationDate
			});
			return RedirectToAction("CheckData");
		}

		public IActionResult CheckData()
		{
			var storedData = Request.Cookies["storedData"];
			return Content($"Stored Data: {storedData}");
		}
	}
}