using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groceries.Models
{
    public class GroceryItem
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Store> Stores { get; set; }
        public int Order { get; set; }
        public Frequency Frequency { get; set; }

    }
}
