using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;
        private readonly RedisCacheService _redisCacheService;

        public WeatherController(MongoDbService mongoDbService, RedisCacheService redisCacheService)
        {
            _mongoDbService = mongoDbService;
            _redisCacheService = redisCacheService;
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetWeather(string locationId)
        {
            // Try to get data from cache
            var cachedData = await _redisCacheService.GetCacheAsync(locationId);
            if (cachedData != null)
            {
                return Ok(new { Source = "Cache", Data = cachedData });
            }

            // Get data from database
            var dbData = await _mongoDbService.GetWeatherDataAsync(locationId);
            if (dbData != null)
            {
                // Store data in cache
                await _redisCacheService.SetCacheAsync(locationId, dbData);
                return Ok(new { Source = "Database", Data = dbData });
            }

            return NotFound("Weather data not found.");
        }

        [HttpPost("reset-cache/{locationId}")]
        public async Task<IActionResult> ResetCache(string locationId)
        {
            await _redisCacheService.ClearCacheAsync(locationId);
            return Ok("Cache cleared for location " + locationId);
        }
    }
}
