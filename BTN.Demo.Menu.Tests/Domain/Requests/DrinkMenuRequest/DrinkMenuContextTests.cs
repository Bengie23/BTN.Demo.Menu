using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
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
            var context = new DrinkMenuContext(data.AsQueryable(), new Dictionary<string, object>() { { AgeEvaluator.CustomerAgeKey, 1 } });

            //Assert
            Assert.IsNotNull(context);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewDrinkMenuContext_Throws_When_NotValid_Data()
        {
            //Arrange
            var data = new List<Drink>();
            //Act
            var context = new DrinkMenuContext(null, new Dictionary<string, object>() { { AgeEvaluator.CustomerAgeKey, 1 } });
        }
    }
}
