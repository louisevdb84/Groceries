using Groceries.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groceries.Web.Pages
{
    public partial class GroceryList
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
        }
        public IEnumerable<GroceryItem> GroceryItems { get; set; }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);

            GroceryItem g1 = new GroceryItem
            {
                Frequency = Frequency.Weekly,
                Description = "Bread",
                Id = 1, 
                Order = 1,
               
                
            };
            GroceryItem g2 = new GroceryItem
            {
                Frequency = Frequency.Weekly,
                Description = "Milk",
                Id = 2,
                Order = 1,
               

            };
            GroceryItem g3 = new GroceryItem
            {
                Frequency = Frequency.Weekly,
                Description = "Sugar",
                Id = 3,
                Order = 1,
               

            };
           GroceryItems = new List<GroceryItem> { g1, g2, g3};
        }

      
    }
}
