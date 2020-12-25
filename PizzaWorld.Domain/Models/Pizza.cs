using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{

    public class Pizza : AEntity
    {
        public string Crust { get; set; }

        public string Size { get; set; }

    }
}
