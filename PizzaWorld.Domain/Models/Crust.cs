using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Crust : APizzaPart
    {
        public Crust(string name, double price) : base(name, price){}
    }
}