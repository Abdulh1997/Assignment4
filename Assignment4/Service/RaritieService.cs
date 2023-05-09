using Assignment4.Modeles;
using MongoDB.Driver;

namespace Assignment4.Service
{
    public class RaritieService
    {
        private readonly ILogger<RaritieService> _logger;
        private readonly IMongoCollection<Rarity> _collection;

        public RaritieService(ILogger<RaritieService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("BED4").GetCollection<Rarity>("rarities");
            _logger = logger;
        }


        public async Task<IList<Rarity>> GetRarities()
        {

            return await _collection.Find<Rarity>(Builders<Rarity>.Filter.Empty).ToListAsync();
        }
    }
}
