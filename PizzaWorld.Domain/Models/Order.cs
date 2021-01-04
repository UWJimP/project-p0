using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        public long StoreID { get; set; }
        public long UserID { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Pizza> Pizzas { get; set; }
        public Order()
        {
            Date = DateTime.Now;
            if(Pizzas == null)
            {
                Pizzas = new List<Pizza>();
            }
        }
        public bool AddPizza(Pizza pizza)
        {
            if(pizza != null && pizza.GetTotalCost() + GetTotalAmount() <= 250d && Pizzas.Count < 50)
            {
                Pizzas.Add(pizza);
                return true;
            }
            return false;
        }
        public void RemovePizza(int index)
        {
            if(index >= 0 && index < Pizzas.Count())
            {
                Pizzas.RemoveAt(index);
            }
        }
        public double GetTotalAmount()
        {
            double cost = 0;
            if(Pizzas == null)
            {
                Pizzas = new List<Pizza>();
            }
            foreach(var pizza in Pizzas)
            {
                cost += pizza.GetTotalCost();
            }
            return cost;
        }
        public override string ToString()
        {
            return $"{Date}: pizzas: {Pizzas.Count()}";
        }
    }
}
