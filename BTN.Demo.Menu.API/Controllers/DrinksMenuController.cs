using BTN.Demo.Menu.Domain.Validation;
using BTN.Demo.Menu.Services;
using BTN.Demo.Menu.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksMenuController : ControllerBase
    {
        private readonly IDrinksService service;

        public DrinksMenuController(IDrinksService service)
        {
            service.ValidateNotNull(nameof(service));
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<DrinkDto>> Get(int? customerAge, bool onlyInStock = false)
        {
            if (onlyInStock)
            {
                if (customerAge.HasValue)
                {
                    var inStockForCustomerDrinks = await service.GetInStockDrinksMenuForCustomer(customerAge.Value);

                    return inStockForCustomerDrinks;
                }
                else
                {
                    var inStockDrinks = await service.GetInStockDrinksMenu();

                    return inStockDrinks;
                }

            }

            if (customerAge.HasValue)
            {
                var drinksForCustomer = await service.GetDrinksMenuForCustomer(customerAge.Value);

                return drinksForCustomer;
            }

            var drinks = await service.GetDrinksMenu();

            return drinks;
        }
    }
}
