using BTN.Demo.Menu.Domain.Helper;

namespace BTN.Demo.Menu.Domain.Entities
{
    /// <summary>
    /// Drink Entity
    /// </summary>
    public class Drink : BaseDrink, IAgeAvailability, IStockAvailability
    {
        public int AvailableAtAge { get; set; } = 0;
        public bool InStock { get; set; } = DrinkExtensions.RandomInStock();
    }
}
