using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class TypeService
    {
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(SeedService dbSeedService, IOptions<MongoDbConfig> config)
        {
            _collection = dbSeedService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<CardType>(config.Value.TypesCollection);
        }

        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            return await _collection.Find(Builders<CardType>.Filter.Empty).ToListAsync();
        }
    }
}
