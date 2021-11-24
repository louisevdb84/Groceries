using Groceries.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groceries.API.Models
{
    public interface IGroceryItemRepository
    {
        Task<IEnumerable<GroceryItem>> GetGroceryItems();
        Task<GroceryItem> GetGroceryItem(int groceryItemId);
        Task<GroceryItem> AddGroceryItem(GroceryItem groceryItem);
        Task<GroceryItem> UpdateGroceryItem(GroceryItem groceryItem);
        void DeleteGroceryItem(int groceryItemId);
    }
}
