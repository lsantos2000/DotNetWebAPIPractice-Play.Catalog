using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Play.Catalog.Service.Repositories
{
    public class ItemRepository
    {
        private const string CollectionName = "items";
        private readonly IMongoCollection<Item> dbCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public ItemRepository()
        {
            var mongoCLient = new MongoClient("mongodb://localhost:27017");
            var database = mongoCLient.GetDatabase("Catalog");
            dbCollection = database.GetCollection<Item>(CollectionName);
        }

        public ItemRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Item>(CollectionName);
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Item item)
        {
            await dbCollection.InsertOneAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await dbCollection.ReplaceOneAsync(filter, item);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }

    }
}