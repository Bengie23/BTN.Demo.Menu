using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Tests.Domain.Requests.DrinkMenuRequest
{
    [TestClass]
    public class RequestBuilderTests
    {
        [TestMethod]
        public void Happy_Path()
        {
            //arrange
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 100 });
            data.Add(new Drink() { AvailableAtAge = 200 });
            data.Add(new Drink() { AvailableAtAge = 300 });
            data.Add(new Drink() { AvailableAtAge = 400 });
            data.Add(new Drink() { AvailableAtAge = 500 });


            var evaluator = new AgeEvaluator()
                                          .FromSingleEvaluator();
            var context = evaluator.WithContext(data.AsQueryable(), 101,null);
                                          
                                          
            //Act                              
            context.Evaluate();

            //Assert
            Assert.AreEqual(1, context.Data.Count());

        }
    }
}
