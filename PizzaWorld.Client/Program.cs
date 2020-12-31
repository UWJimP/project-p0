using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Factory;
using PizzaWorld.Domain.Singletons;
using PizzaWorld.Domain.Abstracts;

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
            MainMenu state = MainMenu.User;
            while(runLoop)
            {
                switch(state)
                {
                    case MainMenu.User: //Create a new user
                        user = CreateUser();
                        if(user == null)
                        {
                            runLoop = false;
                        }
                        state = MainMenu.Stores;
                        break;
                    case MainMenu.Stores: //Prints all stores and select a store.
                        PrintAllStores();
                        Console.WriteLine("Please select a store by its given numbers or any other number to quit: ");
                        user.SelectedStore = _sql.SelectStore();
                        if(user.SelectedStore == null)
                        {
                            runLoop = false;
                        }
                        state = MainMenu.StoresOptions;
                        break;
                    case MainMenu.StoresOptions: //Give options with selected store.
                        PrintStoreOptions();
                        Console.WriteLine($"Welcome to {user.SelectedStore}.");
                        state = SelectStoreOption();
                        break;
                    case MainMenu.Order:
                        MakeOrder(user);
                        state = MainMenu.StoresOptions;
                        break;
                    case MainMenu.ViewHistory:
                        Console.WriteLine("PLEASE IMPLEMENT VIEW HISTORY");
                        state = MainMenu.StoresOptions;
                        break;
                    case MainMenu.ViewStoreHistory:
                        Console.WriteLine("PLEASE IMPLEMENT VIEW STORE HISTORY");
                        state = MainMenu.StoresOptions;
                        break;
                    default:
                        runLoop = false;
                        break;
                }
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
            Console.WriteLine("5. Quit");
        }
        private static MainMenu SelectStoreOption()
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
                            return MainMenu.Order;
                        case 2:
                            return MainMenu.ViewHistory;
                        case 3:
                            return MainMenu.ViewStoreHistory;
                        case 4:
                            return MainMenu.Stores;
                        case 5:
                            return MainMenu.Quit;
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
        private static void MakeOrder(User user)
        {
            var order = new Order();
            bool continueInput = user.AddOrder(new Order());
            PizzaMenu state = PizzaMenu.SelectPizza;
            Pizza pizza = null;
            if(!continueInput)
            {
                Console.WriteLine("Sorry, you cannot make another order within a 2 hour period.");
            }
            while(continueInput)
            {
                switch(state)
                {
                    case(PizzaMenu.SelectPizza):
                        pizza = SelectPizza();
                        state = PizzaMenu.SelectSize;
                        break;
                    case(PizzaMenu.SelectSize):
                        var sizeString = SelectAPart<Size>(_sql.ReadSizes().ToList(), "Select a size: ");
                        //pizza.Size = SelectSize();
                        pizza.Size = APizzaPartFactory.MakeSize(sizeString);
                        state = PizzaMenu.SelectCrust;
                        break;
                    case(PizzaMenu.SelectCrust):
                        //Select crust of pizza
                        var crustString = SelectAPart<Crust>(_sql.ReadCrusts().ToList(), "Select a crust: ");
                        pizza.Crust = APizzaPartFactory.MakeCrust(crustString);
                        state = PizzaMenu.AddTopping;
                        break;
                    case(PizzaMenu.AddTopping):
                        //Add toppings to pizza
                        AddToppings(pizza);
                        state = PizzaMenu.Finish;
                        break;
                    case(PizzaMenu.CheckOrder):
                        //Set up logic here to find
                        break;
                    default:
                        continueInput = false;
                        break;
                }
            }
        }
        private static Pizza SelectPizza()
        {
            while(true)
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
                        Console.WriteLine($"You have selected: a {pizzas[input]} pizza.");
                        Console.WriteLine(selectedPizza);
                        bool confirmation = ConfirmationInput("Is this correct?");
                        if(confirmation)
                        {
                            return selectedPizza;
                        }
                        else
                        {
                            Console.WriteLine($"Pizza was cancelled.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }
        private static Size SelectSize()
        {
            List<Size> sizes = _sql.ReadSizes().ToList();
            while(true)
            {
                for(int index = 0; index < sizes.Count(); index++)
                {
                    Console.WriteLine($"{index}: {sizes[index]}");
                }
                Console.WriteLine("Select a size: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input >= 0 && input < sizes.Count())
                    {
                        return APizzaPartFactory.MakeSize(sizes[input].ToString());
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
        private static string SelectAPart<T>(List<T> list, string message) where T : APizzaPart
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
        private static void AddToppings(Pizza pizza)
        {
            List<Topping> toppings = _sql.ReadToppings().ToList();
            Console.WriteLine("Current toppings: ");
            foreach(var topping in pizza.Toppings)
            {
                Console.Write(topping + " ");
            }
            while(pizza.Toppings.Count < 5)
            {
                for(var index = 0; index < toppings.Count(); index++)
                {
                    Console.WriteLine($"{index}: {toppings[index]} ${toppings[index].Price}");
                }
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input > 0 && input < toppings.Count())
                    {
                        var selectedTopping = APizzaPartFactory.MakeTopping(toppings[input].Name);
                        bool added = pizza.AddTopping(selectedTopping);
                        if(added)
                        {
                            Console.WriteLine($"Added {selectedTopping}");
                        }
                        else
                        {
                            Console.WriteLine("Unable to add topping.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
        private static bool ConfirmationInput(string message)
        {
            while(true) 
            {
                Console.WriteLine($"{message}: y/n");
                var input = Console.ReadLine();
                if(input.ToLower().Equals("y"))
                {
                    return true;
                }
                else if(input.ToLower().Equals("n"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
