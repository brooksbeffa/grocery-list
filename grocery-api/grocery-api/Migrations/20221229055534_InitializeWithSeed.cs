using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace groceryapi.Migrations
{
    /// <inheritdoc />
    public partial class InitializeWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groceries",
                columns: new[] { "GroceryID", "Description", "GroceryListID", "Price" },
                values: new object[,]
                {
                    { "Apples", "1 lb of Honeycrisp apples", null, 2.99m },
                    { "Avocado", "1 Large hass avocado", null, 0.89m },
                    { "Bananas", "1 lb of bananas", null, 0.89m },
                    { "Bread", "Loaf of sliced rye bread", null, 2.99m },
                    { "Chicken Breast", "1 lb of raw chicken breast", null, 4.99m },
                    { "Eggs", "12 large eggs", null, 3.99m },
                    { "Milk", "1 Gallon of whole milk", null, 3.29m }
                });

            migrationBuilder.InsertData(
                table: "GroceryLists",
                columns: new[] { "GroceryListID", "Owner" },
                values: new object[] { "My List", "Joshua Keel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Apples");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Avocado");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Bananas");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Bread");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Chicken Breast");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Eggs");

            migrationBuilder.DeleteData(
                table: "Groceries",
                keyColumn: "GroceryID",
                keyValue: "Milk");

            migrationBuilder.DeleteData(
                table: "GroceryLists",
                keyColumn: "GroceryListID",
                keyValue: "My List");
        }
    }
}
