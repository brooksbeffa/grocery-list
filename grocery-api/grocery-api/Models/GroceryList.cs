using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grocery_api.Models
{
    public class GroceryList
    {
        public string GroceryListID { get; set; }

        // Multiple users not yet supported, but should be in the future. 'Owner' will then be used to determine which user the list belongs to
        public string? Owner { get; set; }

        // Navigation property
        public virtual ICollection<Grocery>? Groceries { get; set; }
    }
}
