using Microsoft.EntityFrameworkCore;
using grocery_api.EfCore;
using grocery_api.Models;
using grocery_api.Repository;

namespace grocery_api.Repository
{
    public class GroceryListRepository : IGroceryListRepository
    {
        private readonly GroceryAppContext _dbContext;

        public GroceryListRepository(GroceryAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<GroceryList> GetAllGroceryLists()
        {
            return _dbContext.GroceryLists.OrderBy(g => g.GroceryListID).AsNoTracking();
        }

        public GroceryList GetGroceryList(string id)
        {
            GroceryList ret = _dbContext.GroceryLists.FirstOrDefault(g => g.GroceryListID.ToLower().Trim() == id.ToLower().Trim());
            
            if(ret != null)
            {
                var ids = _dbContext.GroceryListGroceries.Where(x => x.GroceryListID.ToLower().Trim() == id.ToLower().Trim()).Select(y => y.GroceryID).ToList();
                ret.Groceries = _dbContext.Groceries.Where(z => ids.Contains(z.GroceryID)).ToList();
            }

            return ret;
        }

        public bool GroceryListExists(string id)
        {
            return _dbContext.GroceryLists.Any(g => g.GroceryListID.ToLower().Trim() == id.ToLower().Trim());
        }

        public bool CreateGroceryList(GroceryList list)
        {
            _dbContext.GroceryLists.Add(list);
            return Save();
        }

        public bool UpdateGroceryList(GroceryList list)
        {
            _dbContext.Update(list);
            return Save();
        }

        public bool DeleteGroceryList(string id)
        {
            var list = GetGroceryList(id);
            if (list == null)
                return true; // already deleted

            _dbContext.GroceryLists.Remove(list);
            return Save();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

    }
}