using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;
using WeatherApi.AppSettings;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class RedisCacheService
    {
        private readonly IDatabase _cacheDb;
        private readonly CacheConfig _cacheConfig;

        public RedisCacheService(IConfiguration config, IOptions<CacheConfig> cacheConfigValue)
        {
            _cacheConfig = cacheConfigValue.Value;
            var redis = ConnectionMultiplexer.Connect(_cacheConfig.CacheConnectionString);
            _cacheDb = redis.GetDatabase();
        }

        public async Task SetCacheAsync(string key, WeatherData value)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _cacheDb.StringSetAsync(key, jsonData);
        }

        public async Task<WeatherData?> GetCacheAsync(string key)
        {
            var jsonData = await _cacheDb.StringGetAsync(key);
            if (jsonData.IsNullOrEmpty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<WeatherData>(jsonData);
        }

        public async Task ClearCacheAsync(string key)
        {
            await _cacheDb.KeyDeleteAsync(key);
        }
    }
}
