using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Factory
{
    public class PizzaFactory
    {
        private static readonly List<string> _pizzas = new List<string>()
        {
            "cheese", "pepperoni", "combo", "hawaiian"
        };
        private PizzaFactory(){}
        public static Pizza MakePizza(string pizza, IEnumerable<Topping> toppings)
        {
            var madePizza = new Pizza();
            madePizza.Name = pizza.ToLower();
            //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "cheese"));
            //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "sauce"));
            madePizza.AddTopping(APizzaPartFactory.MakeTopping("cheese"));
            madePizza.AddTopping(APizzaPartFactory.MakeTopping("sauce"));
            switch(pizza.ToLower())
            {
                case "pepperoni":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "pepperoni"));
                    return madePizza;
                case "combo":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "pepperoni"));
                    //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "sausage"));
                    return madePizza;
                case "hawaiian":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pineapple"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "pineapple"));
                    //madePizza.AddTopping(toppings.FirstOrDefault<Topping>(topping => topping.Name == "ham"));
                    return madePizza;
                default:
                    madePizza.Name = "cheese";
                    return madePizza;
            }
        }
        public static List<string> GetAllPizzaStrings()
        {
            return _pizzas;
        }
    }
}