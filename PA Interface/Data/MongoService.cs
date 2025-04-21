using AgricultureOptimization.Models;
using MongoDB.Driver;

namespace AgricultureOptimization.Data
{
    public class MongoService
    {
        private readonly IMongoCollection<Weather> _weatherCollection;
        private readonly IMongoCollection<SoilComposition> _soilCompositionCollection;
        private readonly IMongoCollection<Crop> _cropCollection;

        public MongoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("cropRecommendation");

            _weatherCollection = database.GetCollection<Weather>("Weather");
            _soilCompositionCollection = database.GetCollection<SoilComposition>("SoilComposition");
            _cropCollection = database.GetCollection<Crop>("Crop");
        }

        public async Task<List<Weather>> GetAllWeatherData() =>
            await _weatherCollection.Find(_ => true).ToListAsync();

        public async Task<List<SoilComposition>> GetAllSoilComposition() =>
            await _soilCompositionCollection.Find(_ => true).ToListAsync();

        public async Task<List<Crop>> GetAllCrops() =>
            await _cropCollection.Find(_ => true).ToListAsync();

        public async Task UpdateWeatherAsync(Weather weather) =>
            await _weatherCollection.ReplaceOneAsync(w => w._id == weather._id, weather);
    }
}
