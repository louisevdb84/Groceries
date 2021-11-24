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

        public async void DeleteGroceryItem(int groceryItemId)
        {
            var result = await _appDbContext.GroceryItems
                .FirstOrDefaultAsync(g => g.Id == groceryItemId);
            if(result != null)
            {
                _appDbContext.GroceryItems.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<GroceryItem> GetGroceryItem(int groceryItemId)
        {
            return await _appDbContext.GroceryItems
                .FindAsync(groceryItemId);
        }

        public async Task<IEnumerable<GroceryItem>> GetGroceryItems()
        {
            return await _appDbContext.GroceryItems.ToListAsync();
        }

        public async Task<GroceryItem> UpdateGroceryItem(GroceryItem groceryItem)
        {
            var result = await _appDbContext.GroceryItems
                .FirstOrDefaultAsync(g => g.Id == groceryItem.Id);
            if (result != null)
            {
                result = groceryItem;
                await _appDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
