using Groceries.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Groceries.API.Dtos
{
    public class GroceryItemDto
    {
        public string Description { get; set; }
        public List<StoreDto> Stores { get; set; }
        public int Order { get; set; }
        public Frequency Frequency { get; set; }
    }

    public class CreateGroceryItemDto
    {
        [Required]
        public string Description { get; set; }
        public List<StoreDto> Stores { get; set; }
        public int Order { get; set; }
        public Frequency Frequency { get; set; }
    }
}
