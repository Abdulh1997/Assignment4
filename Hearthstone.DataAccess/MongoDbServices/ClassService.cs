using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class ClassService
    {
        private readonly IMongoCollection<Class> _collection;

        public ClassService(MongoDbService dbMongoDbService, IOptions<MongoDbConfig> config)
        {
            _collection = dbMongoDbService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<Class>(config.Value.ClassesCollection);
        }
        
        public async Task<IReadOnlyList<Class>> GetClasses()
        {
            return await _collection.Find(Builders<Class>.Filter.Empty).ToListAsync();
        }
    }
}
