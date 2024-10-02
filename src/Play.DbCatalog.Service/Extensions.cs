using Play.DbCatalog.Service.Dtos;
using Play.DbCatalog.Service.Entities;

namespace Play.DbCatalog.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description ?? string.Empty, item.Price, item.CreatedDate);
        }
    }
}