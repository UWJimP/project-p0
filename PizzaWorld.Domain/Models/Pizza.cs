using System.Collections.Generic;
using System.Text;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factory;

namespace PizzaWorld.Domain.Models
{
    public class Pizza : AEntity
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public string Name { get; set; }
        public List<Topping> Toppings { get; set; }
        public Pizza()
        {
            DefaultToppings();
        }
        public double GetTotalCost()
        {
            double total = 1d; //Base price of pizza without anything.
            total += Crust.Price;
            total += Size.Price;
            foreach(var topping in Toppings)
            {
                total += topping.Price;
            }
            return total;
        }
        public bool AddTopping(Topping topping)
        {
            if(Toppings == null)
            {
                DefaultToppings();
            }
            if(Toppings.Count < 5)
            {
                Toppings.Add(topping);
                return true;
            }
            return false;
        }
        private void DefaultToppings()
        {
            Toppings = new List<Topping>()
            { 
                APizzaPartFactory.MakeTopping("cheese"),
                APizzaPartFactory.MakeTopping("sauce")
            };
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($"{Name} pizza: ");
            stringBuilder.Append($"price: ${GetTotalCost()} Ingredients: ");
            foreach(var topping in Toppings)
            {
                stringBuilder.Append($"{topping} ");
            }
            return stringBuilder.ToString();
        }
    }
}
