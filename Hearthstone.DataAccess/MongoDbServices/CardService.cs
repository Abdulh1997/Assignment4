﻿using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class CardService
    {
        private readonly IMongoCollection<Card> _collection;

        public CardService(SeedService dbSeedService, IOptions<MongoDbConfig> config)
        {
            _collection = dbSeedService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<Card>(config.Value.CardsCollection);
        }

        public async Task<IReadOnlyList<Card>> GetCards(int? setId = null, int? classId = null, int? rarityId = null, int? typeid = null, string? artist = null, int? page = null)
        {
            var builder = Builders<Card>.Filter;
            var filter = builder.Empty;
            const int pageEntries = 100;


            if (setId != null)
            {
                filter &= builder.Eq(x => x.SetId, setId);
            }

            if (classId != null)
            {
                filter &= builder.Eq(x => x.ClassId, classId);
            }

            if (rarityId != null)
            {
                filter &= builder.Eq(x => x.RarityId, rarityId);
            }

            if (typeid != null)
            {
                filter &= builder.Eq(x => x.TypeId, typeid);
            }

            if (artist?.Length > 0)
            {
                filter &= builder.Regex(x => x.Artist, new BsonRegularExpression($"/{artist}/i"));

            }

            var result = _collection.Find(filter);
            var count = await result.CountDocumentsAsync();

            if (page != null && count >= pageEntries)
            {
                result = result.Skip(page.Value * pageEntries).Limit(pageEntries);
            }

            return await result.ToListAsync();
        }
    }
}
