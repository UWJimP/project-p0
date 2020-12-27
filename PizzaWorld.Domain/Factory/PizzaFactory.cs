using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Factory
{
    public class PizzaFactory
    {
        private PizzaFactory(){}
        public Pizza MakePizza(string pizza)
        {
            var madePizza = new Pizza();
            switch(pizza.ToLower())
            {
                case "pepperoni":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    return madePizza;
                case "combo":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    return madePizza;
                case "meat lover":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    return madePizza;
                case "veggie lover":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("mushroom"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("onion"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("olive"));
                    return madePizza;
                case "hawaiian":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pineapple"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    return madePizza;
                default:
                    return madePizza;
            }
        }
    }
}