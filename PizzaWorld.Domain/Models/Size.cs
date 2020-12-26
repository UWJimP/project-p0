using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Size : APizzaPart
    {
        public Size(string name, double price) : base(name, price){}
    }
}