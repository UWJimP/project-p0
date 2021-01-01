using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        public DateTime Date { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public Order()
        {
            Date = DateTime.Now;
            Pizzas = new List<Pizza>();
        }
        public bool AddPizza(Pizza pizza)
        {
            if(Pizzas != null)
            {
                Pizzas = new List<Pizza>();
            }
            if(pizza.GetTotalCost() + GetTotalAmount() <= 250d && Pizzas.Count < 50)
            {
                Pizzas.Add(pizza);
                return true;
            }
            return false;
        }
        public double GetTotalAmount()
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
