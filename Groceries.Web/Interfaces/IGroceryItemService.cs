using Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.Web.Services
{
    public interface IGroceryItemService
    {
        Task<IEnumerable<GroceryItem>> GetGroceryItems();
    }
}
