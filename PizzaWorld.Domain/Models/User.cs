using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddOrder(Order order)
        {
            if(Orders.Count() == 0) //Checks if the user is new.
            {
                Orders.Add(order);
                return true;
            }
            TimeSpan lastOrderTime = order.Date - Orders.Last().Date;
            if(lastOrderTime.Minutes > 120)
            {
                Orders.Add(order);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Hello {Name}, you are able to order pizza(s) now.";
        }
    }
}
