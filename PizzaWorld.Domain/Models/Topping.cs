using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Topping : APizzaPart
    {
        public Topping(){}
        public Topping(string name) : base(name, 0.75d){}
        public Topping(string name, double price) : base(name, price){}
    }
}