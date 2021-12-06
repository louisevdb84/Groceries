using Groceries.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.API.Models
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly AppDbContext _db;

        public GroceryItemRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<bool> Create(GroceryItem entity)
        {
            await _db.GroceryItems.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(GroceryItem entity)
        {
            _db.GroceryItems.Remove(entity);
            return await Save();
        }

        public async Task<IList<GroceryItem>> FindAll()
        {
           return await _db.GroceryItems.ToListAsync();
        }

        public async Task<GroceryItem> FindById(int id)
        {
            return await _db.GroceryItems.FindAsync(id);
        }

        public async Task<GroceryItem> GetGroceryItemByDesc(string desc)
        {
            return  await _db.GroceryItems
                .FirstOrDefaultAsync(g => g.Description.ToLower() == desc.ToLower());
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(GroceryItem entity)
        {
            _db.GroceryItems.Update(entity);
            return await Save();
        }
    }

}
