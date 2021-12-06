using Groceries.API.Interfaces;
using Groceries.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groceries.API.Models
{
    public interface IGroceryItemRepository : IRepositoryBase<GroceryItem>
    {
        Task<GroceryItem> GetGroceryItemByDesc(string description);
        
    }
}
