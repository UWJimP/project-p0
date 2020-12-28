using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Factory;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {

        private static readonly ClientSingleton _client = ClientSingleton.Instance;
        private static readonly SqlClient _sql = new SqlClient();

        public Program(){}

        static void Main(string[] args)
        {
            UserView();
        }

        private static IEnumerable<Store> GetAllStores()
        {
            return _sql.ReadStores();
        }
        private static void UserView()
        {
            //Creates a user
            var user = CreateUser();

            //Prints all stores and select a store.
            PrintAllStores();
            Console.WriteLine("Please select a store by its given numbers: ");
            user.SelectedStore = _client.SelectStore();

            //Give options with selected store.
            Console.WriteLine($"Welcome to {user.SelectedStore}. Please select one of the options: ");
            PrintStoreOptions();

            //user.SelectedStore.CreateOrder();
            var order = user.SelectedStore.Orders.Last();
            user.Orders.Add(order);
        }
        private static User CreateUser()
        {
            var user = new User();
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            user.Name = name;
            Console.WriteLine(user);
            return user;
        }
        private static void PrintAllStores()
        {
            int index = 0;
            foreach(var store in GetAllStores())
            {
                Console.WriteLine($"{index}. {store}");
            }
        }
        private static void PrintAllPizzas()
        {
            List<string> pizzas = PizzaFactory.GetAllPizzaStrings();
            for(int index = 0; index < pizzas.Count(); index++)
            {
                Console.WriteLine($"{index}: {pizzas[index]}");
            }
        }
        private static void PrintStoreOptions()
        {
            Console.WriteLine("1. Order a Pizza");
            Console.WriteLine("2. View ");
        }
        private static void MakingOrder(User user)
        {
            var order = new Order();
            user.Orders.Add(order);
            bool continueInput = true;
            while(continueInput)
            {
                PrintAllPizzas();
                List<string> pizzas = PizzaFactory.GetAllPizzaStrings();
                Console.WriteLine("Select a pizza you want to order or enter any other number to finish: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input >= 0 && input < pizzas.Count())
                    {
                        var selectedPizza = PizzaFactory.MakePizza(pizzas[input]);
                        Console.WriteLine($"You have added: {pizzas[input]} to your order.");
                        //Add sizes here next Jim
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input a valid input.");
                }
            }
        }
    }
}
