namespace BTN.Demo.Menu.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool  AllowsAlcoholicDrinks { get; set; }
    }
}
