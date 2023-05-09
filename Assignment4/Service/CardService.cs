using Assignment4.Modeles;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Assignment4.Service
{
    public class CardService
    {

        private readonly ILogger<CardService> _logger;
        private readonly IMongoCollection<Card> _collection;

        public CardService(ILogger<CardService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("BED4").GetCollection<Card>("cards");
            _logger = logger;
        }


        public async Task<IList<Card>> GetAllCards()
        {
            return await _collection.Find<Card>(Builders<Card>.Filter.Empty).ToListAsync();
        }



        public async Task<IList<Card>> Search(int? setid = null, int? classid = null, int? rarityid = null, int? typeid = null, string? artist = null, int? page = null)
        {
            var builder = Builders<Card>.Filter;
            var filter = builder.Empty;

            if (setid != null)
            {
                filter &= builder.Eq(x => x.SetId, setid);
            }

            if (classid != null)
            {
                filter &= builder.Eq(x => x.ClassId, classid);
            }

            if (rarityid != null)
            {
                filter &= builder.Eq(x => x.RarityId, rarityid);
            }

            if (typeid != null)
            {
                filter &= builder.Eq(x => x.TypeId, typeid);
            }

            if (artist?.Length > 0)
            {
                filter &= builder.Regex(x => x.Artist, new BsonRegularExpression($"/{artist}/i"));

            }


            //Antal PAges filter
            var Size = 100;
            var result = _collection.Find<Card>(filter);
            var countTask = result.CountDocumentsAsync();
            var count = await countTask;

            if (page != null && count >= Size)
            {
                result = result.Skip(page.Value * Size).Limit(Size);
            }

            return await result.ToListAsync();
        }
    }
}
