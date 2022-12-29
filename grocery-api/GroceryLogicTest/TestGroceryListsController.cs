using grocery_api.Repository;
using grocery_api.Models;
using Moq;
using grocery_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GroceryLogicTest
{

    public class TestGroceryListsController
    {
        private readonly Mock<IGroceryListRepository> listRepoStub = new();
        private readonly Random rand = new();


        // Grocery List Tests


        [Fact]
        public void GetGroceryList_NonExistenList_ReturnsNotFound()
        {
            // Arrange
            listRepoStub.Setup(repo => repo.GetGroceryList("bad id")).Returns((GroceryList)null);
            var controller = new GroceryListsController(listRepoStub.Object);

            // Act
            var result = controller.GetGroceryList("bad id");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }



        [Fact]
        public void GetGrocery_ExistingList_ReturnsExpectedGrocery()
        {
            // Arrange
            GroceryList expectedList = CreateRandomList();
            listRepoStub.Setup(repo => repo.GetGroceryList(expectedList.GroceryListID)).Returns(expectedList);
            var controller = new GroceryListsController(listRepoStub.Object);

            // Act  
            var result = controller.GetGroceryList(expectedList.GroceryListID);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsType<GroceryList>(okResult.Value);
            var list = okResult.Value as GroceryList;
            Assert.Equal(expectedList, list);
        }



        // helper fucntion for tests

        private GroceryList CreateRandomList()
        {
            string randomIdString = Guid.NewGuid().ToString(); ;

            return new GroceryList
            {
                GroceryListID = randomIdString,
                Owner = null,
            };
        }


    }
}