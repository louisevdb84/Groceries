using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Groceries.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<GroceryItem> GroceryItems { get; set; }
    }
}
