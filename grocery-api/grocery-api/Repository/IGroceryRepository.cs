using grocery_api.Models;

namespace grocery_api.Repository
{
    public interface IGroceryRepository
    {
        IQueryable<Grocery> GetAllGroceries();
       
        Grocery GetGrocery(string id);

        bool GroceryExists(string id);

        bool CreateGrocery(Grocery grocery);

        bool UpdateGrocery(Grocery grocery);

        bool DeleteGrocery(string id);

        bool Save();

    }
}
