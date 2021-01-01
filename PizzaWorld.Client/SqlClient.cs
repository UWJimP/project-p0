using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Topping> ReadToppings()
        {
            return _db.Toppings;
        }
        public User ReadOneUser(string name)
        {
            return _db.Users.FirstOrDefault<User>(user => user.Name == name);
        }
        public Store ReadOneStore(string name)
        {
            return _db.Stores.FirstOrDefault<Store>(store => store.Name == name);
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
        public string SelectAPizzaPart<T>(List<T> list, string message) where T : APizzaPart
        {
            while(true)
            {
                for(int index = 0; index < list.Count(); index++)
                {
                    Console.WriteLine($"{index}: {list[index]}");
                }
                Console.WriteLine(message);
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input >= 0 && input < list.Count())
                    {
                        //return APizzaPartFactory.MakeSize(list[input].ToString());
                        return list[input].Name;
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