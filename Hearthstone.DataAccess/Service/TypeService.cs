using Hearthstone.DataAccess.Models;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class TypeService
    {
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<CardType>("types");
        }

        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            return await _collection.Find<CardType>(Builders<CardType>.Filter.Empty).ToListAsync();
        }
    }
}
