using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class DataSeeder
    {
        private readonly MongoDbService _mongoDbService;

        public DataSeeder(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task SeedDataAsync()
        {
            var data = new List<WeatherData>
            {
                new() { LocationId = "1", WeatherDescription = "Sunny", TemperatureCelsius = 25 },
                new() { LocationId = "2", WeatherDescription = "Rainy", TemperatureCelsius = 18 },
                new() { LocationId = "3", WeatherDescription = "Moisty", TemperatureCelsius = 19 },
                new() { LocationId = "4", WeatherDescription = "Cloudy", TemperatureCelsius = 12 },
                new() { LocationId = "5", WeatherDescription = "Rainy", TemperatureCelsius = 20 },
                new() { LocationId = "6", WeatherDescription = "Cloudy", TemperatureCelsius = 12 },
                new() { LocationId = "7", WeatherDescription = "Sunny", TemperatureCelsius = 28 },
                new() { LocationId = "8", WeatherDescription = "Rainy", TemperatureCelsius = 12 },
                new() { LocationId = "9", WeatherDescription = "Cloudy", TemperatureCelsius = 14 },
                new() { LocationId = "10", WeatherDescription = "Moisty", TemperatureCelsius = 10 },
                new() { LocationId = "11", WeatherDescription = "Sunny", TemperatureCelsius = 29 },
                new() { LocationId = "12", WeatherDescription = "Rainy", TemperatureCelsius = 12 },
            };

            foreach (var item in data)
            {
                await _mongoDbService.AddWeatherDataAsync(item);
            }
        }
    }
}
