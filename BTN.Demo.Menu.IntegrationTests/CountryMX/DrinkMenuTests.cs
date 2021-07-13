using BTN.Demo.Menu.Services.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.IntegrationTests.CountryMX
{
    [TestClass]
    public class DrinkMenuTests : BaseIntegrationTests
    {
        [ClassInitialize]
        public static async Task Initialize(TestContext context)
        {
            //overwrites configuration values from appsettings.test.json
            configValues = new Dictionary<string, string>() { { "CountryConfigurationOptions:CountryCode", "MX" } };
            await Initialize();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Dispose();
        }

        [TestMethod]
        public async Task DrinkMenu_Get_Request_Returns_Items_When__Age1()
        {
            var response = await client.GetAsync("api/drinksmenu?customerAge=1");

            var drinksMenu = await response.AssertSuccessfulResponse<IEnumerable<DrinkDto>>();

            Assert.IsTrue(drinksMenu.Any());
        }

        [TestMethod]
        public async Task DrinkMenu_Get_Request_Retruns_Returns_Beers_When_Age18()
        {
            var response = await client.GetAsync("api/drinksmenu?customerAge=18");

            var drinksMenu = await response.AssertSuccessfulResponse<IEnumerable<DrinkDto>>();

            Assert.IsTrue(drinksMenu.Any());

            Assert.AreEqual(4, drinksMenu.Where(drink => drink.BrandName == "Cigar City").Count());
            Assert.AreEqual(4, drinksMenu.Where(drink => drink.BrandName == "The Crown Group").Count());
        }

        [TestMethod]
        public async Task DrinkMenu_Get_Request_Retruns_Returns_Beers_When_Age21()
        {
            var response = await client.GetAsync("api/drinksmenu?customerAge=21");

            var drinksMenu = await response.AssertSuccessfulResponse<IEnumerable<DrinkDto>>();

            Assert.IsTrue(drinksMenu.Any());

            Assert.AreEqual(4, drinksMenu.Where(drink => drink.BrandName == "Cigar City").Count());
            Assert.AreEqual(4, drinksMenu.Where(drink => drink.BrandName == "The Crown Group").Count());

            Assert.AreEqual(4, drinksMenu.Where(drink => drink.BrandName == "The Strong Stuff Company").Count());
        }
    }
}
