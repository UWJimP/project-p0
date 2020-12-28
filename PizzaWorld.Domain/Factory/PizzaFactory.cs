using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Factory
{
    public class PizzaFactory
    {
        private static readonly List<string> _pizzas = new List<string>()
        {
            "cheese", "pepporoni", "combo",
            "meat lover", "veggie lover", "hawaiian"
        };
        private PizzaFactory(){}
        public static Pizza MakePizza(string pizza)
        {
            var madePizza = new Pizza();
            madePizza.Name = pizza.ToLower();
            madePizza.Crust = APizzaPartFactory.MakeCrust("regular");
            madePizza.Size = APizzaPartFactory.MakeSize("small");
            switch(pizza.ToLower())
            {
                case "pepperoni":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.Crust = APizzaPartFactory.MakeCrust("thin");
                    madePizza.EntityID = 2;
                    return madePizza;
                case "combo":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    madePizza.EntityID = 3;
                    return madePizza;
                case "meat lover":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    madePizza.EntityID = 4;
                    return madePizza;
                case "veggie lover":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("mushroom"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("onion"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("olive"));
                    madePizza.Crust = APizzaPartFactory.MakeCrust("pan");
                    madePizza.EntityID = 5;
                    return madePizza;
                case "hawaiian":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pineapple"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    madePizza.Crust = APizzaPartFactory.MakeCrust("pan");
                    madePizza.EntityID = 6;
                    return madePizza;
                default:
                    madePizza.Name = "cheese";
                    madePizza.EntityID = 1;
                    return madePizza;
            }
        }
        public static List<string> GetAllPizzaStrings()
        {
            return _pizzas;
        }
    }
}