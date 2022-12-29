using grocery_api.Models;

namespace grocery_api.Repository
{
    public interface IGroceryListRepository
    {
        IQueryable<GroceryList> GetAllGroceryLists();

        GroceryList GetGroceryList(string id);

        bool GroceryListExists(string id);
        
        bool CreateGroceryList(GroceryList list);
        
        bool UpdateGroceryList(GroceryList list);

        bool DeleteGroceryList(string id);

        bool Save();


    }
}
