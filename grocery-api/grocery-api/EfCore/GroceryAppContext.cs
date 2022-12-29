using Microsoft.EntityFrameworkCore;
using grocery_api.Models;

namespace grocery_api.EfCore
{
    public class GroceryAppContext : DbContext
    {
        
        public DbSet<Grocery> Groceries { get; set; }

        public DbSet<GroceryList> GroceryLists { get; set; }

        public DbSet<GroceryListGrocery> GroceryListGroceries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListGrocery>()
                  .HasKey(glg => new { glg.GroceryListID, glg.GroceryID });

            // Seed GroceryLists
            // add 1 emtpy list "My List"
            modelBuilder.Entity<GroceryList>().HasData(
                new GroceryList { GroceryListID = "My List", Owner = "Joshua Keel" }
            );

            // Seed Groceries
            // add some common groceries
            modelBuilder.Entity<Grocery>().HasData(

                new Grocery { GroceryID = "Bread", Description = "Loaf of sliced rye bread", Price = 2.99M },
                new Grocery { GroceryID = "Eggs", Description = "12 large eggs", Price = 3.99M },
                new Grocery { GroceryID = "Avocado", Description = "1 Large hass avocado", Price = 0.89M },
                new Grocery { GroceryID = "Milk", Description = "1 Gallon of whole milk", Price = 3.29M },
                new Grocery { GroceryID = "Apples", Description = "1 lb of Honeycrisp apples", Price = 2.99M },
                new Grocery { GroceryID = "Bananas", Description = "1 lb of bananas", Price = 0.89M },
                new Grocery { GroceryID = "Chicken Breast", Description = "1 lb of raw chicken breast", Price = 4.99M }
                );
        }



        public GroceryAppContext(DbContextOptions<GroceryAppContext> options) : base(options)
        {

        }

    }
}
