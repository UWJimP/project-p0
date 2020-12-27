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
                    return new Size("large", 3d);
                case "medium":
                    return new Size("medium", 2d);
                default:
                    return new Size("small", 1d);
            }
        }
        public static Crust MakeCrust(string crust)
        {
            switch(crust.ToLower())
            {
                case "thin":
                    return new Crust("thin", 0.5d);
                case "pan":
                    return new Crust("pan", 0.75d);
                case "stuffed":
                    return new Crust("stuffed", 1d);
                default:
                    return new Crust("regular", 0d);
            }
        }
        public static Topping MakeTopping(string topping)
        {
            switch(topping.ToLower())
            {
                case "pepperoni":
                    return new Topping("pepperoni");
                case "sausage":
                    return new Topping("sausage");
                case "pineapple":
                    return new Topping("pineapple");
                case "ham":
                    return new Topping("ham");
                case "onion":
                    return new Topping("onion");
                case "mushroom":
                    return new Topping("mushroom");
                case "bell pepper":
                    return new Topping("bell pepper");
                case "olive":
                    return new Topping("olive");
                case "sauce":
                    return new Topping("sauce", 0);
                default:
                    return new Topping("cheese", 1d);
            }
        }
    }
}