using Assignment4.Modeles;
using MongoDB.Driver;

namespace Assignment4.Service
{
    public class TypeService
    {
        private readonly ILogger<TypeService> _logger;
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(ILogger<TypeService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("BED4").GetCollection<CardType>("types");
            _logger = logger;
        }


        public async Task<IList<CardType>> GetTypes()
        {
            return await _collection.Find<CardType>(Builders<CardType>.Filter.Empty).ToListAsync();
        }
    }
}
