using Groceries.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.API.Models
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public GroceryItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<GroceryItem> AddGroceryItem(GroceryItem groceryItem)
        {
            var result = await _appDbContext.GroceryItems.AddAsync(groceryItem);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GroceryItem> DeleteGroceryItem(int groceryItemId)
        {
            var result = await _appDbContext.GroceryItems
                .FirstOrDefaultAsync(g => g.Id == groceryItemId);
            if(result != null)
            {
                _appDbContext.GroceryItems.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<GroceryItem> GetGroceryItem(int groceryItemId)
        {
            return await _appDbContext.GroceryItems
                .FindAsync(groceryItemId);
        }

        public async Task<GroceryItem> GetGroceryItemByDesc(string description)
        {
            return await _appDbContext.GroceryItems
                .FirstOrDefaultAsync(g => g.Description == description);
        }

        public async Task<IEnumerable<GroceryItem>> GetGroceryItems()
        {
            return await _appDbContext.GroceryItems.ToListAsync();
        }

        public async Task<IEnumerable<GroceryItem>> Search(string description)
        {
            IQueryable<GroceryItem> query = _appDbContext.GroceryItems;

            if(!string.IsNullOrEmpty(description))
            {
                query = query.Where(g => g.Description.Contains(description));
            }
            return await query.ToListAsync();
        }

        public async Task<GroceryItem> UpdateGroceryItem(GroceryItem groceryItem)
        {
            var result = await _appDbContext.GroceryItems
                .FirstOrDefaultAsync(g => g.Id == groceryItem.Id);
            if (result != null)
            {
                result.Description = groceryItem.Description;
                result.Frequency = groceryItem.Frequency;
                result.Order = groceryItem.Order;
               
                await _appDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
