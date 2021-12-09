using AutoMapper;
using Groceries.API.Dtos;
using Groceries.API.Interfaces;
using Groceries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public StoresController(
            IStoreRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var stores = await _repo.FindAll();
                var response = _mapper.Map<IList<StoreDto>>(stores);
                return Ok(response);
            }
            catch (Exception e)
            {
      
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            try
            {
                var result = await _repo.FindById(id);
                if (result == null) return NotFound();
                var response = _mapper.Map<StoreDto>(result);

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Store>> CreateStore([FromBody] Store store)
        {
            try
            {
                if (store == null)
                {
                  
                    return BadRequest(ModelState);
                }

               
                if (!ModelState.IsValid)
                {
                 
                    return BadRequest(ModelState);
                }
                

                var isSuccessful = await _repo.Create(store);
                if (!isSuccessful)
                {
                  
                    return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error creating new record");
                }
                return Created("Created", new { store });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new record");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Store>> UpdateStore(int id, [FromBody] StoreDto storeDto)
        {
            try
            {
                if (id < 1 || storeDto == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var store = _mapper.Map<Store>(storeDto);

                var isSuccess = await _repo.Update(store);

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
        [Authorize]
        public async Task<ActionResult<Store>> DeleteStore(int id)
        {
            try
            {
                if (id < 1)
                    return BadRequest();
                var itemToDelete = await _repo.FindById(id);
                if (itemToDelete == null)
                    return NotFound();
                var isSuccess = await _repo.Delete(itemToDelete);
                if (!isSuccess)
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



