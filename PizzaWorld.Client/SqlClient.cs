using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client
{
    public class SqlClient
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();
        public SqlClient(){}
        public List<Order> ReadOrders(Store store) //How to make generic
        {
            return ReadOneStore(store.Name).Orders;
        }
        public IEnumerable<Size> ReadSizes()
        {
            return _db.Sizes;
        }
        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }
        public IEnumerable<Crust> ReadCrusts()
        {
            return _db.Crusts;
        }
        public User ReadOneUser(string name)
        {
            return _db.Users.FirstOrDefault<User>(user => user.Name == name);
        }
        public Store ReadOneStore(string name)
        {
            return _db.Stores.FirstOrDefault<Store>(store => store.Name == name);
            
        }
        public List<Order> ReadUsersOrders(string name)
        {
            var orders = _db.Users
            .Include(user => user.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .Include(user => user.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(user => user.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .FirstOrDefault<User>(user => user.Name == name);
            return orders.Orders;
        }
        public List<Order> ReadUsersOrdersFromStore(User user)
        {
            var test = _db.Stores
            .Include(store => store.Orders.Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(store => store.Orders.Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .Include(store => store.Orders.Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == user.SelectedStore.EntityID);
            return test.Orders.ToList();
        }
        public List<Order> ReadStoreOrdersByUser(Store store, User user)
        {
            var orders = _db.Stores
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == store.EntityID);
            return orders.Orders.ToList();
        }
        public void PrintSalesByStore(Store store)
        {
            var week = DateTime.Now.AddDays(-7);
            var today = DateTime.Now;
            var orders = _db.Stores
            .Include(s => s.Orders
                .Where(o => o.Date >= week && o.Date <= today))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Size)
            .Include(s => s.Orders
                .Where(o => o.Date >= week && o.Date <= today))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Crust)
            .Include(s => s.Orders
                .Where(o => o.Date >= week && o.Date <= today))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == store.EntityID).Orders.ToList();
            Dictionary<string, int> pizzaCount = new Dictionary<string, int>();
            var amount = 0d;
            foreach(var order in orders)
            {
                amount += order.GetTotalAmount();
                foreach(var pizza in order.Pizzas)
                {
                    if(pizzaCount.ContainsKey(pizza.Name))
                    {
                        pizzaCount[pizza.Name] += 1;
                    }
                    else
                    {
                        pizzaCount.Add(pizza.Name, 1);
                    }
                }
            }
            foreach(var pizzaKey in pizzaCount.Keys)
            {
                Console.WriteLine($"Pizza Type: {pizzaKey} Amount: {pizzaCount[pizzaKey]}");
            }
            Console.WriteLine($"Total Sales Amount: ${amount}");
            Console.WriteLine();
        }
        public void SaveStore(Store store)
        {
            _db.Add(store); //add
            _db.SaveChanges(); //commit
        }
        public void SaveUser(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        public Store SelectStore()
        {
            while(true)
            {
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    return _db.Stores.ToList<Store>().ElementAtOrDefault<Store>(input);
                }
                else
                {
                    Console.WriteLine("Invalid input, input a number");
                }
            }
        }
        public int SelectAPizzaPart<T>(List<T> list, string message) where T : APizzaPart
        {
            while(true)
            {
                for(int index = 0; index < list.Count(); index++)
                {
                    Console.WriteLine($"{index}: {list[index]} ${list[index].Price}");
                }
                Console.WriteLine(message);
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input >= 0 && input < list.Count())
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}