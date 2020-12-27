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
            DefaultToppings();
        }
        public double GetTotalCost()
        {
            double total = 1d; //Base price of pizza without anything.
            if(Crust != null)
            {
                total += Crust.Price;
            }
            if(Size != null)
            {
                total += Size.Price;
            }
            if(Toppings == null)
            {
                DefaultToppings();
            }
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
                new Topping("Cheese", 3d),
                new Topping("Tomato Sauce", 2d)
            };
        }
    }
}
