using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Tests.Domain.Requests.DrinkMenuRequest
{
    [TestClass]
    public class AgeEvaluatorTests
    {
        [TestMethod]
        public void Evaluate_Filters_One_By_Age()
        {
            //Arrange
            var evaluator = new AgeEvaluator();
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 100 });
            data.Add(new Drink() { AvailableAtAge = 200 });
            var context = new DrinkMenuContext(data.AsQueryable(), new Dictionary<string, object>() { { AgeEvaluator.CustomerAgeKey, 101 } });

            //Act
            evaluator.Evaluate(context);

            //Assert
            Assert.AreEqual(1, context.Data.Count());
        }

        [TestMethod]
        public void Evaluate_Filters_Multiple_By_Age()
        {
            //Arrange
            var evaluator = new AgeEvaluator();
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 100 });
            data.Add(new Drink() { AvailableAtAge = 200 });
            data.Add(new Drink() { AvailableAtAge = 300 });
            data.Add(new Drink() { AvailableAtAge = 400 });
            data.Add(new Drink() { AvailableAtAge = 500 });
            var context = new DrinkMenuContext(data.AsQueryable(), new Dictionary<string, object>() { {AgeEvaluator.CustomerAgeKey, 301 } });

            //Act
            evaluator.Evaluate(context);

            //Assert
            Assert.AreEqual(3, context.Data.Count());
        }

        [TestMethod]
        public void Evaluate_Filters_None_By_Age()
        {
            //Arrange
            var evaluator = new AgeEvaluator();
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 100 });
            data.Add(new Drink() { AvailableAtAge = 200 });
            data.Add(new Drink() { AvailableAtAge = 300 });
            data.Add(new Drink() { AvailableAtAge = 400 });
            data.Add(new Drink() { AvailableAtAge = 500 });
            var context = new DrinkMenuContext(data.AsQueryable(), new Dictionary<string, object>() { { AgeEvaluator.CustomerAgeKey, 1 } });

            //Act
            evaluator.Evaluate(context);

            //Assert
            Assert.AreEqual(0, context.Data.Count());
        }

        [TestMethod]
        public void Evaluate_Filters_All_By_Age()
        {
            //Arrange
            var evaluator = new AgeEvaluator();
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 100 });
            data.Add(new Drink() { AvailableAtAge = 200 });
            data.Add(new Drink() { AvailableAtAge = 300 });
            data.Add(new Drink() { AvailableAtAge = 400 });
            data.Add(new Drink() { AvailableAtAge = 500 });
            var context = new DrinkMenuContext(data.AsQueryable(), new Dictionary<string, object>() { { AgeEvaluator.CustomerAgeKey, 501 } });

            //Act
            evaluator.Evaluate(context);

            //Assert
            Assert.AreEqual(data.Count, context.Data.Count());
        }
    }
}
