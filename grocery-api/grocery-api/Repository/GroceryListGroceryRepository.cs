using Microsoft.EntityFrameworkCore;
using grocery_api.EfCore;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Repository
{
    public class GroceryListGroceryRepository : IGroceryListGroceryRepository
    {
        private readonly GroceryAppContext _dbContext;

        public GroceryListGroceryRepository(GroceryAppContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool AddGrocery(string groceryID, string listID)
        {
            if (!_dbContext.Groceries.Any(g => g.GroceryID.ToLower().Trim() == groceryID.ToLower().Trim()))
                return false; // no such grocery

            if (!_dbContext.GroceryLists.Any(g => g.GroceryListID.ToLower().Trim() == listID.ToLower().Trim()))
                return false; // no such list

            if (_dbContext.GroceryListGroceries.Any(x => x.GroceryID.ToLower().Trim() == groceryID.ToLower().Trim() && x.GroceryListID.ToLower().Trim() == listID.ToLower().Trim()))
                return true; // already added

            _dbContext.GroceryListGroceries.Add(new GroceryListGrocery { GroceryListID = listID, GroceryID = groceryID });

            return Save();
        }


        
        public bool RemoveGrocery(string groceryID, string listID)
        {
            if (!_dbContext.Groceries.Any(g => g.GroceryID.ToLower().Trim() == groceryID.ToLower().Trim())) 
                return false; // no such grocery

            if (!_dbContext.GroceryLists.Any(g => g.GroceryListID.ToLower().Trim() == listID.ToLower().Trim()))
                return false; // no such list

            if (!_dbContext.GroceryListGroceries.Any(x => x.GroceryID.ToLower().Trim() == groceryID.ToLower().Trim() && x.GroceryListID.ToLower().Trim() == listID.ToLower().Trim()))
                return true; // already removed

            _dbContext.GroceryListGroceries.Remove(new GroceryListGrocery { GroceryListID = listID, GroceryID = groceryID });

            return Save();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
