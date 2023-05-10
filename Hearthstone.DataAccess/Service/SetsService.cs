using Hearthstone.DataAccess.Models;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class SetsService
    {
        private readonly IMongoCollection<Set> _collection;

        public SetsService(MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<Set>("sets");
        }

        public async Task<IReadOnlyList<Set>> GetSets()
        {
            return await _collection.Find(Builders<Set>.Filter.Empty).ToListAsync();
        }
    }
}
