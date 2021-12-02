using Groceries.Models;
using System.Collections.Generic;

namespace Groceries.API.Dtos
{
    public class GroceryItemDto
    {
        public string Description { get; set; }
        public List<StoreDto> Stores { get; set; }
        public int Order { get; set; }
        public Frequency Frequency { get; set; }
    }
}
