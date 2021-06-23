using BTN.Demo.Menu.Data.Data;
using BTN.Demo.Menu.Data.DbContext;
using BTN.Demo.Menu.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Tests.Data
{
    [TestClass]
    public class DrinksRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewDrinksRepository_Throws_When_Null_DBContext()
        {
            //Arrange
            var context = (DrinkDbContext)null;
            //Act
            _ = new DrinksRepository(context);
        }

        [TestMethod]
        public async Task DrinksRepository_Seeds_Data()
        {
            //Arrange
            var context = new DrinkDbContext();
            var repo = new DrinksRepository(context);

            //Act

            //at this point there are no records
            var previousData = await repo.GetDrinks();
            Assert.IsFalse(previousData.Count() > 0);

            var dataSeed = new DrinkDataSeed(repo);
            await dataSeed.Run();

            //Assert
            var data = await repo.GetDrinks();
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count() > 0);
        }

        [TestMethod]
        public async Task DrinksRepository_Resets_Data()
        {
            //Arrange
            var context = new DrinkDbContext();
            var repo = new DrinksRepository(context);
            var dataSeed = new DrinkDataSeed(repo);

            //Act
            await dataSeed.Run();

            var data = await repo.GetDrinks();
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count() > 0);

            await repo.Reset();

            //Assert

            var postData = await repo.GetDrinks();
            Assert.IsNotNull(postData);
            Assert.IsTrue(postData.Count() ==  0);
        }
    }
}
