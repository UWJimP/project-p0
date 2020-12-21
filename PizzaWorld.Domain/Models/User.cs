using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{

    public class User
    {
        public List<Order> Orders { get; set; }

        public Store SelectedStore { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"I have selected this store: {SelectedStore}";
        }

    }
}
