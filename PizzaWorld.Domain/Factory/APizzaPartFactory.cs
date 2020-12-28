using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Factory
{
    public class APizzaPartFactory
    {
        private APizzaPartFactory(){}
        public static Size MakeSize(string size)
        {
            switch(size.ToLower())
            {
                case "large":
                    return new Size("large", 3d) { EntityID = 2};
                case "medium":
                    return new Size("medium", 2d) { EntityID = 3};
                default:
                    return new Size("small", 1d) { EntityID = 1};
            }
        }
        public static Crust MakeCrust(string crust)
        {
            switch(crust.ToLower())
            {
                case "thin":
                    return new Crust("thin", 1.5d) { EntityID = 2 };
                case "pan":
                    return new Crust("pan", 1.75d) { EntityID = 3 };
                default:
                    return new Crust("regular", 1d) { EntityID = 1 };
            }
        }
        public static Topping MakeTopping(string topping)
        {
            switch(topping.ToLower())
            {
                case "pepperoni":
                    return new Topping("pepperoni") { EntityID = 2};
                case "sausage":
                    return new Topping("sausage") { EntityID = 3};
                case "pineapple":
                    return new Topping("pineapple") { EntityID = 4};
                case "ham":
                    return new Topping("ham") { EntityID = 5};
                case "onion":
                    return new Topping("onion") { EntityID = 6};
                case "mushroom":
                    return new Topping("mushroom") { EntityID = 7};
                case "olive":
                    return new Topping("olive") { EntityID = 8};
                case "sauce":
                    return new Topping("sauce", 2d) { EntityID = 9};
                default:
                    return new Topping("cheese", 1d) { EntityID = 1};
            }
        }
    }
}