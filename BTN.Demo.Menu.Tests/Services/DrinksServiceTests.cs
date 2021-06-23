using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Tests.Services
{
    [TestClass]
    public class DrinksServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrinksService_Throws_When_NotValid_Argument()
        {
            var service = new DrinksService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task GetDrinksMenuForCustomer_Throws_When_NotValid_Argument()
        {
            var repo = new Mock<IDrinksRepository>();
            var service = new DrinksService(repo.Object);

            await service.GetDrinksMenuForCustomer(0);
        }

        [TestMethod]
        public async Task GetDrinksMenuForCustomer_Happy_Path()
        {
            var repo = new Mock<IDrinksRepository>();
            var data = new List<Drink>();
            data.Add(new Drink() { AvailableAtAge = 1, Name = "Drink for Age 1", BrandName = "Test", Id = Guid.NewGuid() });
            data.Add(new Drink() { AvailableAtAge = 5, Name = "Drink for Age 5", BrandName = "Test", Id = Guid.NewGuid() });
            data.Add(new Drink() { AvailableAtAge = 11, Name = "Drink for Age 11", BrandName = "Test", Id = Guid.NewGuid() });

            repo.Setup(repo => repo.GetDrinks()).ReturnsAsync(data.AsQueryable());

            var service = new DrinksService(repo.Object);

            var drinksMenu = await service.GetDrinksMenuForCustomer(10);

            Assert.IsNotNull(drinksMenu);
            Assert.AreEqual(2, drinksMenu.Count());
            Assert.IsFalse(drinksMenu.Any(d => d.Name == "Drink for Age 11"));
        }
    }
}
