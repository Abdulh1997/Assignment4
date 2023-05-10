using System.Text.Json;
using Hearthstone.DataAccess.Models;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.Service
{
    public class MongoDbSeedService
    {
        public MongoClient Client { get; }

        public MongoDbSeedService(string? connectionString)
        {
            Client = new MongoClient(connectionString);
        }

        public async Task SeedMongoDb()
        {
            var db = Client.GetDatabase("BED4");

            if ((await Client.GetDatabase("BED4").ListCollectionsAsync()).ToList().Count != 0) return;

            // SEED cards.json Data
            var collection = db.GetCollection<Card>("cards");

            foreach (var path in new[] { "cards.json" })
            {
                using var file = new StreamReader(path);
                var cards = JsonSerializer.Deserialize<List<Card>>(await file.ReadToEndAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                await collection.InsertManyAsync(cards);
            }

            var collectionSets = db.GetCollection<Set>("sets");
            var collectionRarities = db.GetCollection<Rarity>("rarities");
            var collectionClasses = db.GetCollection<Class>("classes");
            var collectionTypes = db.GetCollection<CardType>("types");

            using (var file = new StreamReader("metadata.json"))
            {
                var meta = JsonSerializer.Deserialize<MetaData>(await file.ReadToEndAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                await collectionSets.InsertManyAsync(meta!.Sets);
                await collectionRarities.InsertManyAsync(meta.Rarities);
                await collectionClasses.InsertManyAsync(meta.Classes);
                await collectionTypes.InsertManyAsync(meta.Types);
            }
        }
    }
}
