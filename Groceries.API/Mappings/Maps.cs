using AutoMapper;
using Groceries.API.Dtos;
using Groceries.Models;

namespace Groceries.API.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<GroceryItem, GroceryItemDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();  
        }
        
    }
}
