namespace grocery_api.Repository
{
    public interface IGroceryListGroceryRepository
    {
        bool AddGrocery(string groceryID, string listID);

        bool RemoveGrocery(string groceryID, string listID);

        bool Save();
    }
}
