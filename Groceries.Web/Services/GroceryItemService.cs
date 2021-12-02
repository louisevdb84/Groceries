using Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Groceries.Web.Services
{
    public class GroceryItemService : IGroceryItemService
    {
        private readonly HttpClient _httpClient;

        public GroceryItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<GroceryItem>> GetGroceryItems()
        {
            return await _httpClient.GetFromJsonAsync<GroceryItem[]>("api/groceryitems");
        }
    }
}
