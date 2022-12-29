using Microsoft.EntityFrameworkCore;
using grocery_api.EfCore;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly GroceryAppContext _dbContext;

        public GroceryRepository(GroceryAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Grocery> GetAllGroceries()
        {
            return _dbContext.Groceries.OrderBy(g => g.GroceryID).AsNoTracking();
        }

        public Grocery GetGrocery(string id)
        {
            return _dbContext.Groceries.FirstOrDefault(g => g.GroceryID.ToLower().Trim() == id.ToLower().Trim());
        }

        public bool GroceryExists(string id)
        {
            return _dbContext.Groceries.Any(g => g.GroceryID.ToLower().Trim() == id.ToLower().Trim());
        }

        public bool CreateGrocery(Grocery grocery)
        {
            // handle duplicate
            _dbContext.Groceries.Add(grocery);
            return Save();
        }

        public bool UpdateGrocery(Grocery grocery)
        {
            _dbContext.Update(grocery);
            return Save();
        }

        public bool DeleteGrocery(string groceryID)
        {
            var grocery = GetGrocery(groceryID);
            if (grocery == null)
                return true; // already deleted

            _dbContext.Groceries.Remove(grocery);
            return Save();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

    }
}