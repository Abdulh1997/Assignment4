using Assignment4.Modeles;
using MongoDB.Driver;
using System.Text.Json;

namespace Assignment4.Service
{
    public class MongoService
    {
        private readonly MongoClient _client;
        public MongoService()
        {
            _client = new MongoClient("mongodb://root:example@localhost:27018");
            var db = _client.GetDatabase("BED4");
            if (_client.GetDatabase("BED4").ListCollections().ToList().Count == 0)
            {

                // SEED cards.json Data
                var collection = db.GetCollection<Card>("cards");
                foreach (var path in new[] { "cards.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collection.InsertMany(cards);
                    }
                }



                // SEED meta.json Data
                var collectionSets = db.GetCollection<Set>("sets");
                var collectionRarities = db.GetCollection<Rarity>("rarities");
                var collectionClasses = db.GetCollection<Class>("classes");
                var collectionTypes = db.GetCollection<CardType>("types");

                using (var file = new StreamReader("metadata.json"))
                {
                    var meta = JsonSerializer.Deserialize<MetaData>(file.ReadToEnd(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    collectionSets.InsertMany(meta.Sets);
                    collectionRarities.InsertMany(meta.Rarities);
                    collectionClasses.InsertMany(meta.Classes);
                    collectionTypes.InsertMany(meta.Types);


                }
            }
        }

        public MongoClient Client
        {
            get
            {
                return _client;
            }
        }
    }
}
