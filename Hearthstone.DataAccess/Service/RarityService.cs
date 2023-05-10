using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class RarityService
    {
        private readonly ILogger<RarityService> _logger;
        private readonly IMongoCollection<Rarity> _collection;

        public RarityService(ILogger<RarityService> logger, MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<Rarity>("rarities");
            _logger = logger;
        }

        public async Task<IReadOnlyList<Rarity>> GetRarities()
        {

            return await _collection.Find(Builders<Rarity>.Filter.Empty).ToListAsync();
        }
    }
}
