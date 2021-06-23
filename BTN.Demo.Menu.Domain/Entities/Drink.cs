namespace BTN.Demo.Menu.Domain.Entities
{
    /// <summary>
    /// Drink Entity
    /// </summary>
    public class Drink : BaseDrink, IAgeAvailability
    {
        public int AvailableAtAge { get; set; } = 0;
    }
}
