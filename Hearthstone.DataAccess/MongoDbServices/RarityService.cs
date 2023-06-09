﻿using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.DataAccess.MongoDbServices
{
    public class RarityService
    {
        private readonly IMongoCollection<Rarity> _collection;

        public RarityService(MongoDbService dbMongoDbService, IOptions<MongoDbConfig> config)
        {
            _collection = dbMongoDbService.Client.GetDatabase(config.Value.DatabaseName).GetCollection<Rarity>(config.Value.RaritiesCollection);
        }

        public async Task<IReadOnlyList<Rarity>> GetRarities()
        {

            return await _collection.Find(Builders<Rarity>.Filter.Empty).ToListAsync();
        }
    }
}
