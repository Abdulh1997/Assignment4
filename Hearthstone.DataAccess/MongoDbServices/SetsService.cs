using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class SetsService
    {
        private readonly IMongoCollection<Set> _collection;

        public SetsService(MongoDbService dbMongoDbService, IOptions<MongoDbConfig> config)
        {
            _collection = dbMongoDbService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<Set>(config.Value.SetsCollection);
        }

        public async Task<IReadOnlyList<Set>> GetSets()
        {
            return await _collection.Find(Builders<Set>.Filter.Empty).ToListAsync();
        }
    }
}
