using Microsoft.AspNetCore.Mvc;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceriesController(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }


        // get all groceries
        // GET: api/Groceries
        [HttpGet]
        public IActionResult GetAll()
        {
            var groceries = _groceryRepository.GetAllGroceries();
            return Ok(groceries);
        }

        // get grocery by id
        // GET: api/Groceries/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetGrocery(string id)
        {
            var grocery = _groceryRepository.GetGrocery(id);
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        // create grocery
        // POST: api/Groceries/Create
        [HttpPost("Create")]
        public IActionResult CreateGrocery([FromBody] Grocery grocery)
        {
            if (grocery == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_groceryRepository.GroceryExists(grocery.GroceryID))
            {
                ModelState.AddModelError("", "Grocery already exists");
                return StatusCode(409, ModelState);
            }
            if (!_groceryRepository.CreateGrocery(grocery))
            {
                ModelState.AddModelError("", $"Something went wrong creating {grocery.GroceryID}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction("GetGrocery", new { id = grocery.GroceryID }, grocery);
        }

        // update grocery
        // PUT: api/Groceries/Update
        [HttpPut("Update")]
        public IActionResult UpdateGrocery([FromBody] Grocery grocery)
        {
            if (grocery == null)
            {
                return BadRequest(); // Status code 400
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Status code 400
            }
            if (!_groceryRepository.GroceryExists(grocery.GroceryID))
            {
                ModelState.AddModelError("", "Grocery dosn't exist");
                return StatusCode(404, ModelState);
            }
            if (!_groceryRepository.UpdateGrocery(grocery))
            {
                ModelState.AddModelError("", $"Something went wrong updating {grocery.GroceryID}");
                return StatusCode(500, ModelState);
            }      
            
            return NoContent();
        }

        // delete grocery
        // DELETE: api/Groceries/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteGrocery(string id)
        {
            if (!_groceryRepository.GroceryExists(id))
            {
                ModelState.AddModelError("", "Grocery dosn't exist");
                return NotFound(ModelState);
            }
  
            if (!_groceryRepository.DeleteGrocery(id))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {id}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
