using Groceries.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groceries.API.Models
{
    public interface IGroceryItemRepository
    {
        Task<IEnumerable<GroceryItem>> GetGroceryItems();
        Task<IEnumerable<GroceryItem>> Search(string description);
        Task<GroceryItem> GetGroceryItem(int groceryItemId);
        Task<GroceryItem> GetGroceryItemByDesc(string description);
        Task<GroceryItem> AddGroceryItem(GroceryItem groceryItem);
        Task<GroceryItem> UpdateGroceryItem(GroceryItem groceryItem);
        Task<GroceryItem> DeleteGroceryItem(int groceryItemId);
    }
}
