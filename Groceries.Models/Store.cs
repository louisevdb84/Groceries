using System;
using System.Collections.Generic;

namespace Groceries.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GroceryItem> GroceryItems { get; set; }
    }
}
