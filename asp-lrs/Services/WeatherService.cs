using System;
using System.Net.Http;
using System.Threading.Tasks;
using asp_lrs.Models;
using Newtonsoft.Json;

namespace asp_lrs.Services
{ 
    public class WeatherService{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.openweathermap.org");
    }

    public async Task<WeatherViewModel> GetWeatherAsync(string cityName)
    {
        try
        {
            string apiKey = "2e856ca90d17790876a57121158dfb88"; // Замініть на ваш API ключ\
            string requestUrl = $"/data/2.5/weather?q={cityName}&appid={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();

            var weatherData = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(jsonString);

            var weatherViewModel = new WeatherViewModel
            {
                City = weatherData.Name,
                Country = weatherData.Sys.Country,
                Temperature = weatherData.Main.Temperature - 273.15,
                Description = weatherData.Weather[0].Description
            };

            return weatherViewModel;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to get weather data.", ex);
        }
    }
}


    public class OpenWeatherMapResponse
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        public Weather[] Weather { get; set; }
        public Sys Sys { get; set; }
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }
    public class Sys
{
    public string Country { get; set; }
    public int Sunrise { get; set; }
    public int Sunset { get; set; }
}
}
