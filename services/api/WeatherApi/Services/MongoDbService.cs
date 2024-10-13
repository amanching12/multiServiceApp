using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using MongoDB.Driver;
using WeatherApi.AppSettings;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class MongoDbService
    {
        private readonly DBConfig _dbConfig;
        private readonly IMongoCollection<WeatherData> _weatherCollection;

        public MongoDbService(IOptions<DBConfig> configOptions)
        {
            _dbConfig = configOptions.Value;
            var client = new MongoClient(_dbConfig.DBConnectionString);
            var database = client.GetDatabase(_dbConfig.DatabaseName);
            _weatherCollection = database.GetCollection<WeatherData>(nameof(WeatherData));
        }

        public async Task<WeatherData> GetWeatherDataAsync(string locationId)
        {
            return await _weatherCollection.Find(x => x.LocationId == locationId).FirstOrDefaultAsync();
        }

        public async Task AddWeatherDataAsync(WeatherData data)
        {
            await _weatherCollection.InsertOneAsync(data);
        }
    }
}
