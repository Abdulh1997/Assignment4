using Hearthstone.DataAccess.Models;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class RarityService
    {
        private readonly IMongoCollection<Rarity> _collection;

        public RarityService(MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<Rarity>("rarities");
        }

        public async Task<IReadOnlyList<Rarity>> GetRarities()
        {

            return await _collection.Find(Builders<Rarity>.Filter.Empty).ToListAsync();
        }
    }
}
