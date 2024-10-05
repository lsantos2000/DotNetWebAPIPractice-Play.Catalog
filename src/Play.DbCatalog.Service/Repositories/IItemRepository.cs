using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.DbCatalog.Service.Entities;

namespace Play.DbCatalog.Service.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(Guid id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task CreateAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}