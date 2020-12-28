using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class User : AEntity
    {
        public string Name { get; set; }
        public Store SelectedStore { get; set; }
        public List<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"Hello {Name}, you are able to order pizza(s) now.";
        }
    }
}
