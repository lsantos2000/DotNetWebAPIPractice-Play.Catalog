using Play.Catalog.Service.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Play.Catalog.Service.Repositories
{
    public interface IItemRepository
    {
        Task<IReadOnlyCollection<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(Guid id);
        Task CreateAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}