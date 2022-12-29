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

        private readonly IGroceryListRepository _groceryListRepository;

        private readonly IGroceryListGroceryRepository _groceryListGroceryRepository;


        public GroceriesController(IGroceryRepository groceryRepository, IGroceryListRepository groceryListRepository, IGroceryListGroceryRepository groceryListGroceryRepository)
        {
            _groceryRepository = groceryRepository;
            _groceryListRepository = groceryListRepository;
            _groceryListGroceryRepository = groceryListGroceryRepository;
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






        //// I decided to combine my controllers into one for the following reasons:
        //// - grants assess to Exists() functions when adding groceries to lists
        //// - total size of the combined controller is still very managable
        //// - All functionality revolves around groceries, so the namespace makes sense. For example "api/Groceries/AddToList" is still logical
        //// - In essense, groceryLists are very closely tied to and dependent on groceries, so it made sense to keep them together



        // get all grocery lists
        // GET: api/Groceries/GetAllLists
        [HttpGet("GetAllLists")]
        public IActionResult GetAllGroceryLists()
        {
            var groceryLists = _groceryListRepository.GetAllGroceryLists();
            return Ok(groceryLists);
        }

        // get grocery list by id
        // GET: api/Groceries/Get/{id}
        [HttpGet("GetList/{id}")]
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
        // POST: api/Groceries/CreateList
        [HttpPost("CreateList")]
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
        // PUT: api/Groceries/UpdateList
        [HttpPut("UpdateList")]
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
        // DELETE: api/Groceries/Delete/{id}
        [HttpDelete("DeleteList/{id}")]
        public IActionResult DeleteGroceryList(string id)
        {
            if (!_groceryListRepository.GroceryListExists(id))
            {
                return NotFound();
            }
            _groceryListRepository.DeleteGroceryList(id);
            return NoContent();
        }



        // And finally, we bring it all together with endpoints for adding and removing groceries from grocery lists


        // add grocery to groceryList
        // POST: api/Groceries/AddToList/{groceryID}/{listID}
        [HttpPost("AddToList/{groceryID}/{listID}")]
        public IActionResult AddGrocery(string groceryID, string listID)
        {
            if (!_groceryRepository.GroceryExists(groceryID))
            {
                ModelState.AddModelError("", $"Could not find Grocery {groceryID}");  // add model error to differentiate between grocery not found and list not found
                return NotFound(ModelState);
            }
            if (!_groceryListRepository.GroceryListExists(listID))
            {
                ModelState.AddModelError("", $"Could not find Grocery List {listID}");// add model error to differentiate between grocery not found and list not found
                return NotFound(ModelState);
            }
            _groceryListGroceryRepository.AddGrocery(groceryID, listID);
            return NoContent();
        }

        // remove grocery from grocery list
        // DELETE: api/Groceries/RemoveGrocery/{groceryID}/{listID}
        [HttpDelete("RemoveFromList/{groceryID}/{listID}")]
        public IActionResult RemoveGrocery(string groceryID, string listID)
        {
            if (!_groceryRepository.GroceryExists(groceryID))
            {
                ModelState.AddModelError("", $"Could not find Grocery {groceryID}");  // add model error to differentiate between grocery not found and list not found
                return NotFound(ModelState);
            }
            if (!_groceryListRepository.GroceryListExists(listID))
            {
                ModelState.AddModelError("", $"Could not find Grocery List {listID}");// add model error to differentiate between grocery not found and list not found
                return NotFound(ModelState);
            }
            _groceryListGroceryRepository.RemoveGrocery(groceryID, listID);
            return NoContent();
        }


    }
}
