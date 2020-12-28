using System;
using System.Collections.Generic;
using System.Linq;
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

/*         public T ReadOrders<T>(Store store) where T : List<Order>, new()
        {
            return ReadOneStore(store.Name).Orders;
        } */

        public IEnumerable<Size> ReadSizes()
        {
            return _db.Sizes;
        }

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
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
        public void UpdateStore(Store store)
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
    }
}