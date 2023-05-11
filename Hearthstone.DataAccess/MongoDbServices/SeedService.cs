using System.Text.Json;
using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class SeedService
    {
        public MongoClient Client { get; }

        private readonly IOptions<MongoDbConfig> _config;

        public SeedService(IOptions<MongoDbConfig> config)
        {
            _config = config;
            Client = new MongoClient(_config.Value.ConnectionString);
        }

        public async Task SeedMongoDb()
        {
            var db = Client.GetDatabase(_config.Value.DatabaseName);

            if ((await Client.GetDatabase(_config.Value.DatabaseName).ListCollectionsAsync()).ToList().Count != 0) return;

            var collection = db.GetCollection<Card>(_config.Value.CardsCollection);

            foreach (var path in new[] { "cards.json" })
            {
                using var file = new StreamReader(path);
                var cards = JsonSerializer.Deserialize<List<Card>>(await file.ReadToEndAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                await collection.InsertManyAsync(cards);
            }

            var collectionSets = db.GetCollection<Set>(_config.Value.SetsCollection);
            var collectionRarities = db.GetCollection<Rarity>(_config.Value.RaritiesCollection);
            var collectionClasses = db.GetCollection<Class>(_config.Value.ClassesCollection);
            var collectionTypes = db.GetCollection<CardType>(_config.Value.TypesCollection);

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
