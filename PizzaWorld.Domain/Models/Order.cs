using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        public List<Pizza> Pizzas { get; set; }
        public Order()
        {
            Pizzas = new List<Pizza>();
        }
        public bool AddPizza(Pizza pizza)
        {
            if(Pizzas != null)
            {
                Pizzas = new List<Pizza>();
            }
            if(pizza.GetTotalCost() + GetTotalCost() <= 250d && Pizzas.Count < 50)
            {
                Pizzas.Add(pizza);
                return true;
            }
            return false;
        }
        public double GetTotalCost()
        {
            double cost = 0;
            if(Pizzas != null)
            {
                Pizzas = new List<Pizza>();
            }
            foreach(var pizza in Pizzas)
            {
                cost += pizza.GetTotalCost();
            }
            return cost;
        }
    }
}
