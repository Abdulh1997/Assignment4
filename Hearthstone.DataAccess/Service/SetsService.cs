using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class SetsService
    {
        private readonly ILogger<SetsService> _logger;
        private readonly IMongoCollection<Set> _collection;

        public SetsService(ILogger<SetsService> logger, MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<Set>("sets");
            _logger = logger;
        }


        public async Task<IReadOnlyList<Set>> GetSets()
        {
            return await _collection.Find(Builders<Set>.Filter.Empty).ToListAsync();
        }
    }
}
