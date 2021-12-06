using AutoMapper;
using Groceries.API.Dtos;
using Groceries.API.Interfaces;
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
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public GroceryItemsController(
            IGroceryItemRepository groceryItemRepository, 
            ILoggerService logger,
            IMapper mapper)
        {
            _groceryItemRepo = groceryItemRepository;
            _logger = logger;
            _mapper = mapper;
        }

       
        /// <summary>
        /// Get list of all groceries 
        /// </summary>
        /// <returns>List of groceries</returns>
        [HttpGet]
        public async Task<IActionResult> GetGroceryItems()
        {           
            try
            {
                _logger.LogInfo("Accessed Get GroceryItems");
                var groceryitems = await _groceryItemRepo.FindAll();
                var response = _mapper.Map<IList<GroceryItemDto>>(groceryitems);
                _logger.LogInfo("Success");
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} - {e.InnerException}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        /// <summary>
        /// Gets a grocery item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItem>> GetGroceryItem(int id)
        {
            try
            {
                var result = await _groceryItemRepo.FindById(id);
                if (result == null) return NotFound();
                var response = _mapper.Map<GroceryItemDto>(result);               
               
                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroceryItem>> CreateGroceryItem([FromBody]CreateGroceryItemDto groceryItemDto)
        {
            try
            {
                if (groceryItemDto == null)
                {
                    _logger.LogWarn("Empty groceryitem");
                    return BadRequest(ModelState);
                }

                if (await _groceryItemRepo.GetGroceryItemByDesc(groceryItemDto.Description) != null)
                {
                    _logger.LogWarn("Item already exists");
                    ModelState.AddModelError("Grocery Item", "Grocery Item already added");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn("Data incomplete");
                    return BadRequest(ModelState);
                }
                var groceryItem = _mapper.Map<GroceryItem>(groceryItemDto);
                   
                var isSuccessful = await _groceryItemRepo.Create(groceryItem);
                if(!isSuccessful)
                {
                    _logger.LogWarn("Author creating failed");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error creating new record");
                }
                return Created("Created", new { groceryItem });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroceryItem>> UpdateGroceryItem(int id, [FromBody] CreateGroceryItemDto groceryItemDto)
        {
            try
            {
                if (id < 1 || groceryItemDto == null)
                    return BadRequest();
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var groceryItem = _mapper.Map<GroceryItem>(groceryItemDto);

                var isSuccess = await _groceryItemRepo.Update(groceryItem);

                if (!isSuccess)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error updating data");

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<GroceryItem>> DeleteGroceryItem(int id)
        {
            try
            {
                if (id < 1)
                    return BadRequest();
                var itemToDelete = await _groceryItemRepo.FindById(id);
                if (itemToDelete == null)
                    return NotFound();
                var isSuccess = await _groceryItemRepo.Delete(itemToDelete);
                if(!isSuccess)
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error deleting data");

                return NoContent();



            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }

}
