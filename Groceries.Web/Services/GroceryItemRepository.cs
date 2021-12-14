using Blazored.LocalStorage;
using Groceries.Web.Interfaces;
using Groceries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Groceries.Web.Services
{
    public class GroceryItemRepository: BaseRepository<GroceryItem>, IGroceryItemRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localstorage;

        public GroceryItemRepository(IHttpClientFactory client, ILocalStorageService localStorage)
            :base(client, localStorage)
        {
            _client = client;
            _localstorage = localStorage;
        }
    }
}
