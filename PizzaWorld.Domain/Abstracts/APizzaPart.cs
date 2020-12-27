namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaPart : AEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        protected APizzaPart(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}