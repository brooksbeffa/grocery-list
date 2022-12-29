using grocery_api.Repository;
using grocery_api.Models;
using Moq;
using Xunit;
using grocery_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GroceryLogicTest
{

    public class TestGroceryiesController
    {
        private readonly Mock<IGroceryRepository> groceryRepoStub = new();
        private readonly Mock<IGroceryListRepository> listRepoStub = new();
        private readonly Mock<IGroceryListGroceryRepository> listGroceryRepoStub = new();

        private readonly Random rand = new();


        // naming convention: MethodName_StateUnderTest_ExpectedBehavior
        [Fact]
        public void GetGrocery_NonExistentItem_ReturnsNotFound()
        {
            // Arrange
            groceryRepoStub.Setup(repo => repo.GetGrocery("bad id"))
                .Returns((Grocery)null);

            var controller = new GroceriesController(groceryRepoStub.Object, listRepoStub.Object, listGroceryRepoStub.Object);
            // Act
            var result = controller.GetGrocery("bad id");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }



        [Fact]
        public void GetGrocery_ExistingItem_ReturnsExpectedGrocery()
        {
            // Arrange
            Grocery expectedGrocery = CreateRandomGrocery();
            
            
            groceryRepoStub.Setup(repo => repo.GetGrocery(expectedGrocery.GroceryID))
                .Returns(expectedGrocery);


            var controller = new GroceriesController(groceryRepoStub.Object, listRepoStub.Object, listGroceryRepoStub.Object);

            // Act  
            var result = controller.GetGrocery(expectedGrocery.GroceryID);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsType<Grocery>(okResult.Value);
            var grocery = okResult.Value as Grocery;
            Assert.Equal(expectedGrocery, grocery);
        }




        // helper fucntion for tests
        private Grocery CreateRandomGrocery()
        {

            string randomIdString = Guid.NewGuid().ToString(); ;

            return new Grocery
            {
                GroceryID = randomIdString,
                Description = null,
                Price = rand.Next(100),
            };

        }


    }
}