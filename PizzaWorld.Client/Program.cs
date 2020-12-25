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
        private static readonly SqlClient _sql = new SqlClient();

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

        static void PrintAllStoresWithEF()
        {
            foreach(var store in _sql.ReadStores())
            {
                System.Console.WriteLine(store);
            }
        }

        static void UserView()
        {
            var user = new User();

            PrintAllStoresWithEF();
            user.SelectedStore = _client.SelectStore();
            Console.WriteLine(user);
            user.SelectedStore.CreateOrder();
            var order = user.SelectedStore.Orders.Last();
            user.Orders.Add(order);
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
