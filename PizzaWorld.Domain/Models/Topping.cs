using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Topping : APizzaPart
    {
        public Topping(string name, double price) : base(name, price)
        {
        }
    }
}