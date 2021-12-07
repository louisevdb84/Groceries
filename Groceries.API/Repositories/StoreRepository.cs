using Groceries.API.Interfaces;
using Groceries.API.Models;
using Groceries.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.API.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Store entity)
        {
            await _context.Stores.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Store entity)
        {
            _context.Stores.Remove(entity);
            return await Save();
        }

        public async Task<IList<Store>> FindAll()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> FindById(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Store entity)
        {
            _context.Stores.Update(entity);
            return await Save();
        }
    }
}
