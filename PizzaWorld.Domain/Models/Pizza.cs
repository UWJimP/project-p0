using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Pizza : AEntity
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public List<Topping> Toppings { get; set; }
        public Pizza()
        {
            Toppings = new List<Topping>()
            { 
                new Topping("Cheese", 3d),
                new Topping("Tomato Sauce", 2d)
            };
        }
        public double GetTotalCost()
        {
            double total = Crust.Price + Size.Price;
            if(Toppings != null)
            {
                foreach(var topping in Toppings)
                {
                    total += topping.Price;
                }
            }
            return total;
        }
        public bool AddTopping(Topping topping)
        {
            if(Toppings != null && Toppings.Count < 5)
            {
                Toppings.Add(topping);
                return true;
            }
            return false;
        }
    }
}
