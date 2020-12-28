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
            User user = null;
            bool runLoop = true;
            MenuState state = MenuState.User;
            while(runLoop)
            {
                switch(state)
                {
                    case MenuState.User: //Create a new user
                        user = CreateUser();
                        if(user == null)
                        {
                            runLoop = false;
                        }
                        state = MenuState.Stores;
                        break;
                    case MenuState.Stores: //Prints all stores and select a store.
                        PrintAllStores();
                        Console.WriteLine("Please select a store by its given numbers or any other number to quit: ");
                        user.SelectedStore = _sql.SelectStore();
                        if(user.SelectedStore == null)
                        {
                            runLoop = false;
                        }
                        state = MenuState.StoresOptions;
                        break;
                    case MenuState.StoresOptions: //Give options with selected store.
                        PrintStoreOptions();
                        Console.WriteLine($"Welcome to {user.SelectedStore}.");
                        state = SelectStoreOption();
                        break;
                    case MenuState.Order:
                        MakingOrder(user);
                        state = MenuState.StoresOptions;
                        break;
                    default:
                        runLoop = false;
                        break;
                }
            }

            if(user.SelectedStore != null) // Continue with the program.
            {
                //user.SelectedStore.CreateOrder();
                var order = user.SelectedStore.Orders.Last();
                user.Orders.Add(order);
            }
            Console.WriteLine("Thank you, have a nice day!");
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
            IEnumerable<Store> stores = GetAllStores();
            for(var index = 0; index < stores.Count(); index++)
            {
                Console.WriteLine($"{index}. {stores.ElementAtOrDefault(index)}");
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
            Console.WriteLine("2. View Your Order History");
            Console.WriteLine("3. View Your Order History with this Store");
            Console.WriteLine("4. Select another Store");
            Console.WriteLine("4. Quit");
        }
        private static MenuState SelectStoreOption()
        {
            while(true)
            {
                Console.WriteLine("Please select one of the options: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    switch(input)
                    {
                        case 1:
                            return MenuState.Order;
                        case 2:
                            return MenuState.ViewHistory;
                        case 3:
                            return MenuState.ViewStoreHistory;
                        case 4:
                            return MenuState.Stores;
                        case 5:
                            return MenuState.Quit;
                        default:
                            Console.WriteLine("Invalid number input, try again: ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please put in a number.");
                }
            }
        }
        private static void MakingOrder(User user)
        {
            var order = new Order();
            //user.Orders.Add(order);
            bool continueInput = user.AddOrder(new Order());
            if(!continueInput)
            {
                Console.WriteLine("Sorry, you cannot make another order within a 2 hour period.");
            }
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
                        continueInput = false;
                        Console.WriteLine("Thank you for your order.");
                        Console.WriteLine($"Your total is: {order.GetTotalCost()}");
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
