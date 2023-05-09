using Assignment4.Modeles;
using MongoDB.Driver;

namespace Assignment4.Service
{
    public class SetsService
    {
        private readonly ILogger<SetsService> _logger;
        private readonly IMongoCollection<Set> _collection;

        public SetsService(ILogger<SetsService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("BED4").GetCollection<Set>("sets");
            _logger = logger;

        }


        public async Task<IList<Set>> GetSets()
        {

            return await _collection.Find<Set>(Builders<Set>.Filter.Empty).ToListAsync();
        }

    }
}
