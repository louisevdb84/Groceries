using System.Collections.Generic;

namespace Groceries.API.Dtos
{
    public class StoreDto
    {
        public string Name { get; set; }
        public List<GroceryItemDto> GroceryItems { get; set; }
    }
}
