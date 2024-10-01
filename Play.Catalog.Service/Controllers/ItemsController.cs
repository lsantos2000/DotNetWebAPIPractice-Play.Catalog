using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new List<ItemDto>
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of health", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Shield", "Provides a small amount of protection", 15, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Helmet", "Provides a small amount of head protection", 10, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Boots", "Increases movement speed slightly", 8, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Ring", "Grants a small amount of magical power", 25, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Amulet", "Grants a small amount of magical resistance", 30, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Gloves", "Increases grip strength slightly", 12, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Cloak", "Provides a small amount of stealth", 18, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Belt", "Increases carrying capacity slightly", 10, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bracers", "Provides a small amount of arm protection", 14, DateTimeOffset.UtcNow)
        };

        // GET /api/items
        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> Get()
        {
            return Ok(items);
        }

        // GET /api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = items.SingleOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST /api/items
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT /api/items/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = items.SingleOrDefault(item => item.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };

            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items[index] = updatedItem;

            return NoContent();
        }

        // DELETE /api/items/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            items.RemoveAt(index);

            return NoContent();
        }

        // GET /api/items/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<ItemDto>> Search(string name)
        {
            var matchedItems = items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/price-range
        [HttpGet("price-range")]
        public ActionResult<IEnumerable<ItemDto>> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var matchedItems = items.Where(item => item.Price >= minPrice && item.Price <= maxPrice).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/recent
        [HttpGet("recent")]
        public ActionResult<IEnumerable<ItemDto>> GetRecentItems(int count = 5)
        {
            var recentItems = items.OrderByDescending(item => item.CreatedDate).Take(count).ToList();
            return Ok(recentItems);
        }

        // GET /api/items/sorted
        [HttpGet("sorted")]
        public ActionResult<IEnumerable<ItemDto>> GetSortedItems(string sortBy = "name")
        {
            IEnumerable<ItemDto> sortedItems = sortBy.ToLower() switch
            {
                "price" => items.OrderBy(item => item.Price),
                "createddate" => items.OrderBy(item => item.CreatedDate),
                _ => items.OrderBy(item => item.Name)
            };

            return Ok(sortedItems);
        }

        // GET /api/items/paged
        [HttpGet("paged")]
        public ActionResult<IEnumerable<ItemDto>> GetPagedItems(int pageNumber = 1, int pageSize = 10)
        {
            var pagedItems = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedItems);
        }

        // GET /api/items/count
        [HttpGet("count")]
        public ActionResult<int> GetItemCount()
        {
            return Ok(items.Count);
        }

        // GET /api/items/exists/{id}
        [HttpGet("exists/{id}")]
        public ActionResult<bool> ItemExists(Guid id)
        {
            var exists = items.Any(item => item.Id == id);
            return Ok(exists);
        }

        // GET /api/items/distinct-names
        [HttpGet("distinct-names")]
        public ActionResult<IEnumerable<string>> GetDistinctNames()
        {
            var distinctNames = items.Select(item => item.Name).Distinct().ToList();
            return Ok(distinctNames);
        }

        // GET /api/items/total-value
        [HttpGet("total-value")]
        public ActionResult<decimal> GetTotalValue()
        {
            var totalValue = items.Sum(item => item.Price);
            return Ok(totalValue);
        }

        // GET /api/items/average-price
        [HttpGet("average-price")]
        public ActionResult<decimal> GetAveragePrice()
        {
            var averagePrice = items.Average(item => item.Price);
            return Ok(averagePrice);
        }

        // GET /api/items/grouped-by-price
        [HttpGet("grouped-by-price")]
        public ActionResult<IEnumerable<IGrouping<decimal, ItemDto>>> GetItemsGroupedByPrice()
        {
            var groupedItems = items.GroupBy(item => item.Price).ToList();
            return Ok(groupedItems);
        }

        // GET /api/items/by-description
        [HttpGet("by-description")]
        public ActionResult<IEnumerable<ItemDto>> GetByDescription(string description)
        {
            var matchedItems = items.Where(item => item.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-name-and-price
        [HttpGet("by-name-and-price")]
        public ActionResult<IEnumerable<ItemDto>> GetByNameAndPrice(string name, decimal price)
        {
            var matchedItems = items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase) && item.Price == price).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-creation-date
        [HttpGet("by-creation-date")]
        public ActionResult<IEnumerable<ItemDto>> GetByCreationDate(DateTimeOffset creationDate)
        {
            var matchedItems = items.Where(item => item.CreatedDate.Date == creationDate.Date).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-name-or-description
        [HttpGet("by-name-or-description")]
        public ActionResult<IEnumerable<ItemDto>> GetByNameOrDescription(string searchTerm)
        {
            var matchedItems = items.Where(item => item.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || item.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-name-length
        [HttpGet("by-name-length")]
        public ActionResult<IEnumerable<ItemDto>> GetByNameLength(int length)
        {
            var matchedItems = items.Where(item => item.Name.Length == length).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-description-length
        [HttpGet("by-description-length")]
        public ActionResult<IEnumerable<ItemDto>> GetByDescriptionLength(int length)
        {
            var matchedItems = items.Where(item => item.Description.Length == length).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-name-starts-with
        [HttpGet("by-name-starts-with")]
        public ActionResult<IEnumerable<ItemDto>> GetByNameStartsWith(string prefix)
        {
            var matchedItems = items.Where(item => item.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-description-starts-with
        [HttpGet("by-description-starts-with")]
        public ActionResult<IEnumerable<ItemDto>> GetByDescriptionStartsWith(string prefix)
        {
            var matchedItems = items.Where(item => item.Description.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-name-ends-with
        [HttpGet("by-name-ends-with")]
        public ActionResult<IEnumerable<ItemDto>> GetByNameEndsWith(string suffix)
        {
            var matchedItems = items.Where(item => item.Name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

        // GET /api/items/by-description-ends-with
        [HttpGet("by-description-ends-with")]
        public ActionResult<IEnumerable<ItemDto>> GetByDescriptionEndsWith(string suffix)
        {
            var matchedItems = items.Where(item => item.Description.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchedItems.Any())
            {
                return NotFound();
            }

            return Ok(matchedItems);
        }

    }
}