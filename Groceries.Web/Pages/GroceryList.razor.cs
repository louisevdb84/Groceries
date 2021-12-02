using Groceries.Models;
using Groceries.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.Web.Pages
{
    public partial class GroceryList
    {
        [Inject]
        public IGroceryItemService GroceryItemService { get; set; }
      
        public IEnumerable<GroceryItem> GroceryItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GroceryItems = (await GroceryItemService.GetGroceryItems()).ToList();

        }
      
    }
}
