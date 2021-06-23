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
        public async Task<IEnumerable<DrinkDto>> Get(int customerAge)
        {
            var drinks = await service.GetDrinksMenuForCustomer(customerAge);

            return drinks;
        }
    }
}
