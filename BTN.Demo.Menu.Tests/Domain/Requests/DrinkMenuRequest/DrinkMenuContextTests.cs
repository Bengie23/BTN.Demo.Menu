using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Tests.Domain.Requests.DrinkMenuRequest
{
    [TestClass]
    public class DrinkMenuContextTests
    {
        [TestMethod]
        public void NewDrinkMenuContext_Constructs_When_Valid_Arguments()
        {
            //Arrange
            var data = new List<Drink>();
            //Act
            var context = new DrinkMenuContext(data.AsQueryable(), 1);

            //Assert
            Assert.IsNotNull(context);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NewDrinkMenuContext_Throws_When_NotValid_CustomerAge()
        {
            //Arrange
            var data = new List<Drink>();
            //Act
            var context = new DrinkMenuContext(data.AsQueryable(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewDrinkMenuContext_Throws_When_NotValid_Data()
        {
            //Arrange
            var data = new List<Drink>();
            //Act
            var context = new DrinkMenuContext(null, 1);
        }
    }
}
