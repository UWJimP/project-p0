using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {

        private static readonly ClientSingleton _client = ClientSingleton.Instance;

        public Program()
        {
        }

        static void Main(string[] args)
        {
            UserView();
        }

        static IEnumerable<Store> GetAllStores()
        {
            return _client.Stores;
        }

        static void UserView()
        {
            var user = new User();

            PrintAllStores();
            user.SelectedStore = _client.SelectStore();
            Console.WriteLine(user);
            user.SelectedStore.CreateOrder();
            var order = user.SelectedStore.Orders.Last();
            user.Orders.Add(order);
            order
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
