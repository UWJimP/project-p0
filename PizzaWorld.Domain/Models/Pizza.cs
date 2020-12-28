using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factory;

namespace PizzaWorld.Domain.Models
{
    public class Pizza : AEntity
    {
        public long? CrustID { get; set; }
        public long? SizeID { get; set; }

        [ForeignKey("CrustID")]
        public Crust Crust { get; set; }

        [ForeignKey("SizeID")]
        public Size Size { get; set; }
        public List<Topping> Toppings { get; set; }
        public Pizza()
        {
            Crust = APizzaPartFactory.MakeCrust("regular");
            Size = APizzaPartFactory.MakeSize("small");
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
    }
}
