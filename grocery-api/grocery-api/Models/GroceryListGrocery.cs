using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grocery_api.Models
{
    public class GroceryListGrocery
    {
        [Key]
        [Column(Order = 1)]
        public string GroceryListID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string GroceryID { get; set; }
        }

}
