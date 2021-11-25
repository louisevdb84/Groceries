using Groceries.API.Models;
using Groceries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryItemsController : ControllerBase
    {
        private readonly IGroceryItemRepository _groceryItemRepo;

        public GroceryItemsController(IGroceryItemRepository groceryItemRepository)
        {
            _groceryItemRepo = groceryItemRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GroceryItem>>> Search(string description)
        {
            try
            {
                var result = await _groceryItemRepo.Search(description);

                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetGroceryItems()
        {
            try
            {
                return Ok(await _groceryItemRepo.GetGroceryItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GroceryItem>> GetGroceryItem(int id)
        {
            try
            {
                var result = await _groceryItemRepo.GetGroceryItem(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroceryItem>> CreateGroceryItem(GroceryItem groceryItem)
        {
            try
            {
                if(groceryItem == null)
                {
                    return BadRequest();                    
                }

                if(_groceryItemRepo.GetGroceryItemByDesc(groceryItem.Description) != null)
                {
                    ModelState.AddModelError("Grocery Item", "Grocery Item already added");
                    return BadRequest(ModelState);
                }
                var createdItem = await _groceryItemRepo.AddGroceryItem(groceryItem);
                Console.WriteLine(nameof(GetGroceryItem));
                return CreatedAtAction(nameof(GetGroceryItem),
                    new { id = createdItem.Id }, createdItem);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GroceryItem>> UpdateGroceryItem(int id, GroceryItem item)
        {
            try
            {
                if (id != item.Id)
                    return BadRequest("GroceryItem ID mismatch");

                var itemToUpdate = await _groceryItemRepo.GetGroceryItem(id);

                if (itemToUpdate == null)
                    return NotFound($"Grocery Item with Id = {id} not found");

                return await _groceryItemRepo.UpdateGroceryItem(item);
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<GroceryItem>> DeleteGroceryItem(int id)
        {
            try
            {
                var itemToDelete = await _groceryItemRepo.GetGroceryItem(id);
                if(itemToDelete==null)
                {
                    return NotFound("Grocery item to delete was not found");
                }
                return await _groceryItemRepo.DeleteGroceryItem(id);

                

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }

}
