using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class TypeService
    {
        private readonly ILogger<TypeService> _logger;
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(ILogger<TypeService> logger, MongoDbSeedService dbSeedService)
        {
            _collection = dbSeedService.Client.GetDatabase("BED4").GetCollection<CardType>("types");
            _logger = logger;
        }

        public async Task<IReadOnlyList<CardType>> GetTypes()
        {
            return await _collection.Find<CardType>(Builders<CardType>.Filter.Empty).ToListAsync();
        }
    }
}
