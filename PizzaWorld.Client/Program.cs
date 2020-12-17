using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = ClientSingleton.Instance;
            cs.MakeStore();
            //PrintAllStores();
        }

        static IEnumerable<Store> GetAllStores()
        {
            List<Store> stores = new List<Store>()
            {
                new Store()
            };

            return stores;
        }

        static void PrintAllStores()
        {
            foreach(Store store in GetAllStores())
            {
                Console.WriteLine(store);
            }
        }
    }
}
