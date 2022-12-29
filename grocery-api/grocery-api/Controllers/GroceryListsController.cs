using Microsoft.AspNetCore.Mvc;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        private readonly IGroceryListRepository _groceryListRepository;
        

        public GroceryListsController(IGroceryListRepository groceryListRepository)
        {
            _groceryListRepository = groceryListRepository;
        }


        // get all grocery lists
        // GET: api/GroceryLists
        [HttpGet]
        public IActionResult GetAll()
        {
            var groceryLists = _groceryListRepository.GetAllGroceryLists();
            return Ok(groceryLists);
        }

        // get grocery list by id
        // GET: api/GroceryLists/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetGroceryList(string id)
        {
            var groceryList = _groceryListRepository.GetGroceryList(id);
            if (groceryList == null)
            {
                return NotFound();
            }
            return Ok(groceryList);
        }

        // create grocery list
        // POST: api/GroceryLists/Create
        [HttpPost("Create")]
        public IActionResult CreateGroceryList([FromBody] GroceryList groceryList)
        {
            if (groceryList == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_groceryListRepository.GroceryListExists(groceryList.GroceryListID))
            {
                return Conflict();
            }
            _groceryListRepository.CreateGroceryList(groceryList);
            return CreatedAtAction("GetGroceryList", new { id = groceryList.GroceryListID }, groceryList);
        }

        // update grocery list
        // PUT: api/GroceryLists/Update
        [HttpPut("Update")]
        public IActionResult UpdateGroceryList([FromBody] GroceryList groceryList)
        {
            if (groceryList == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_groceryListRepository.GroceryListExists(groceryList.GroceryListID))
            {
                return NotFound();
            }
            _groceryListRepository.UpdateGroceryList(groceryList);
            return NoContent();
        }

        // delete grocery list
        // DELETE: api/GroceryLists/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteGroceryList(string id)
        {
            if (!_groceryListRepository.GroceryListExists(id))
            {
                return NotFound();
            }
            _groceryListRepository.DeleteGroceryList(id);
            return NoContent();
        }


    }
}
