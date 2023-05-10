using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class ClassService
    {
        private readonly ILogger<ClassService> _logger;
        private readonly IMongoCollection<Class> _collection;

        public ClassService(ILogger<ClassService> logger, MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<Class>("classes");
            _logger = logger;
        }
        
        public async Task<IReadOnlyList<Class>> GetClasses()
        {
            _logger.LogInformation("GetClasses request received.");

            var response = await _collection.Find(Builders<Class>.Filter.Empty).ToListAsync();

            _logger.LogInformation($"GetClasses request completed. {response.Count} classes found.");

            return response;
        }
    }
}
