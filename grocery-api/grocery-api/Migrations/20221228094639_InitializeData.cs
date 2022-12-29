using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace groceryapi.Migrations
{
    /// <inheritdoc />
    public partial class InitializeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryListGroceries",
                columns: table => new
                {
                    GroceryListID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroceryID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryListGroceries", x => new { x.GroceryListID, x.GroceryID });
                });

            migrationBuilder.CreateTable(
                name: "GroceryLists",
                columns: table => new
                {
                    GroceryListID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryLists", x => x.GroceryListID);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    GroceryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    GroceryListID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.GroceryID);
                    table.ForeignKey(
                        name: "FK_Groceries_GroceryLists_GroceryListID",
                        column: x => x.GroceryListID,
                        principalTable: "GroceryLists",
                        principalColumn: "GroceryListID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_GroceryListID",
                table: "Groceries",
                column: "GroceryListID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "GroceryListGroceries");

            migrationBuilder.DropTable(
                name: "GroceryLists");
        }
    }
}
