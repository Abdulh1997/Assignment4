using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class TypeService
    {
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(MongoDbService dbMongoDbService, IOptions<MongoDbConfig> config)
        {
            _collection = dbMongoDbService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<CardType>(config.Value.TypesCollection);
        }

        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            return await _collection.Find(Builders<CardType>.Filter.Empty).ToListAsync();
        }
    }
}
