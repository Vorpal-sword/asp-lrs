using asp_lrs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace asp_lrs.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        // Конструктор контролера, приймає WeatherService як параметр
        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Метод, який повертає представлення для відображення погоди
        public IActionResult Index()
        {
            return View();
        }

        // Метод для обробки запиту на отримання погодних даних
        [HttpPost]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            try
            {
                // Викликаємо метод сервісу для отримання погоди
                var weatherInfo = await _weatherService.GetWeatherAsync(cityName);

                // Повертаємо дані про погоду як результат запиту
                return Ok(weatherInfo);
            }
            catch
            {
                // Повертаємо помилку статусу 500 у випадку невдачі
                return StatusCode(500);
            }
        }
    }
}