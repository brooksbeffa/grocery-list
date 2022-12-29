using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListGroceriesController : ControllerBase
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IGroceryListGroceryRepository _groceryListGroceryRepository;

        public GroceryListGroceriesController(IGroceryRepository groceryRepository, IGroceryListRepository groceryListRepository, IGroceryListGroceryRepository groceryListGroceryRepository)
        {
            _groceryRepository = groceryRepository;
            _groceryListRepository = groceryListRepository;
            _groceryListGroceryRepository = groceryListGroceryRepository;
        }


        // add grocery to groceryList
        // POST: api/GroceryListGroceries/Add/{groceryID}/{listID}
        [HttpPost("AddGrocery/{groceryID}/{listID}")]
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
        // DELETE: api/GroceryListGroceries/RemoveGrocery/{groceryID}/{listID}
        [HttpDelete("RemoveGrocery/{groceryID}/{listID}")]
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
