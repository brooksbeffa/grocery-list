using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grocery_api.Models
{
    public class Grocery
    {    
        public string GroceryID { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }

        // Navitgation property
        //public virtual ICollection<GroceryListGrocery>? GroceryListsGroceries { get; set; }
    }
}
