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
            EntryView();
        }
        private static IEnumerable<Store> GetAllStores()
        {
            return _sql.ReadStores();
        }
        private static void EntryView()
        {
            var user = CreateUser();
            if(user.Name.ToLower() == "admin")
            {
                AdminView();
            }
            else
            {
                UserView(user);
            }
        }
        private static void AdminView()
        {
            bool runLoop = true;
            MainMenu state = MainMenu.AdminOptions;
            while(runLoop)
            {
                switch(state)
                {
                    case MainMenu.AdminOptions:
                        state = SelectAdminOptions();
                        break;
                    case MainMenu.AdminOrderHistory:
                        break;
                    case MainMenu.AdminSalesHistory:
                        break;
                    default:
                        runLoop = false;
                        break;
                }
            }
        }
        private static void UserView(User user)
        {
            //User user = null;
            bool runLoop = true;
            //MainMenu state = MainMenu.User;
            MainMenu state = MainMenu.Stores;
            while(runLoop)
            {
                switch(state)
                {
/*                     case MainMenu.User: //Create a new user
                        user = CreateUser();
                        if(user == null)
                        {
                            runLoop = false;
                        }
                        state = MainMenu.Stores;
                        break; */
                    case MainMenu.Stores: //Prints all stores and select a store.
                        //PrintAllStores();
                        PrintItems<Store>(GetAllStores().ToList());
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
                        if(user.Orders.Count <= 0)
                        {
                            Console.WriteLine("You have no orders.");
                        }
                        else
                        {
                            PrintItems<Order>(user.Orders);
                        }
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
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            User user = _sql.ReadOneUser(name.Trim());
            if(user == null)
            {
                user = new User();
                user.Name = name.Trim();
                _sql.SaveUser(user);
            }
            else
            {
                //Console.WriteLine("Found user");
                List<Order> orders = _sql.ReadUsersOrders(name.Trim());
                if(orders != null)
                {
                    var store = _sql.ReadStores().ToList()[0];
                    var test1 = _sql.ReadOrdersByStore(store);
                    user.Orders = orders;
                    var order = orders[0];
                    var pizza = _sql.ReadPizzasByOrder(order);
                    Console.WriteLine(pizza);
                }
            }
            Console.WriteLine(user);
            return user;
        }
        private static void PrintItems<T>(List<T> list)
        {
            for(int index = 0; index < list.Count; index++)
            {
                Console.WriteLine($"{index}: {list[index]}");
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
        private static void PrintAdminOptions()
        {
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. Quit");
        }
        private static MainMenu SelectAdminOptions()
        {
            while(true)
            {
                PrintAdminOptions();
                Console.WriteLine("Please select one of these options: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    switch(input)
                    {
                        case 1:
                            return MainMenu.AdminOrderHistory;
                        case 2:
                            return MainMenu.AdminSalesHistory;
                        case 3:
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
                if(order.Pizzas.Count() >= 50)
                {
                    state = PizzaMenu.Finish;
                    Console.WriteLine("You have 50 pizzas, completing order.");
                }
                switch(state)
                {
                    case(PizzaMenu.SelectPizza):
                        pizza = SelectPizza();
                        state = PizzaMenu.SelectSize;
                        break;
                    case(PizzaMenu.SelectSize):
                        List<Size> sizes =  _sql.ReadSizes().ToList();
                        var sizeString = _sql.SelectAPizzaPart<Size>(sizes,
                         "Select a size: ");
                        //pizza.Size = SelectSize();
                        pizza.Size = sizes.ElementAtOrDefault<Size>(sizeString);
                        //pizza.Size = APizzaPartFactory.MakeSize(sizeString);
                        state = PizzaMenu.SelectCrust;
                        break;
                    case(PizzaMenu.SelectCrust):
                        List<Crust> crusts = _sql.ReadCrusts().ToList();
                        var crustString = _sql.SelectAPizzaPart<Crust>(_sql.ReadCrusts().ToList(),
                         "Select a crust: ");
                        //pizza.Crust = APizzaPartFactory.MakeCrust(crustString);
                        pizza.Crust = crusts.ElementAtOrDefault<Crust>(crustString);
                        bool addTopping = ConfirmationInput("Would you like to add toppings?");
                        if(addTopping)
                        {
                            state = PizzaMenu.AddTopping;
                            pizza.Name = "custom";
                        }
                        else
                        {
                            state = PizzaMenu.CheckOrder;
                        }
                        break;
                    case(PizzaMenu.AddTopping):
                        AddToppings(pizza);
                        state = PizzaMenu.CheckOrder;
                        break;
                    case(PizzaMenu.CheckOrder):
                        bool canAddPizza = order.AddPizza(pizza);
                        if(!canAddPizza)
                        {
                            Console.WriteLine("Sorry, your order would put you over the limit of $250.");
                            Console.WriteLine("Either complete your order or add another pizza.");
                        }
                        Console.WriteLine($"Your current total is: ${order.GetTotalAmount()} with {order.Pizzas.Count()} pizza(s).");
                        bool confirmation = ConfirmationInput("Would you like to add another pizza?");
                        if(confirmation)
                        {
                           state = PizzaMenu.SelectPizza; 
                        }
                        else
                        {
                            state = PizzaMenu.Finish;
                            Console.WriteLine("We have completed your order. Thank you for your time.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Your total is: ${order.GetTotalAmount()} with {order.Pizzas.Count()} pizza(s).");
                        continueInput = false;
                        user.SelectedStore.Orders.Add(order);
                        _sql.SaveChanges();
                        break;
                }
            }
        }
        private static Pizza SelectPizza()
        {
            while(true)
            {
                //PrintAllPizzas();
                List<string> pizzas = PizzaFactory.GetAllPizzaStrings();
                PrintItems<string>(pizzas);
                Console.WriteLine("Select a pizza you want to order or enter any other number to finish: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int input);
                if(validInput)
                {
                    if(input >= 0 && input < pizzas.Count())
                    {
                        var selectedPizza = PizzaFactory.MakePizza(pizzas[input], _sql.ReadToppings());
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
        private static void AddToppings(Pizza pizza)
        {
            List<Topping> toppings = APizzaPartFactory.GetToppings();
            Console.WriteLine("Current toppings: ");
            foreach(var topping in pizza.Toppings)
            {
                Console.Write(topping + " ");
            }
            Console.WriteLine(); //Just to start a new line.
            while(pizza.Toppings.Count < 5)
            {
                for(var index = 0; index < toppings.Count(); index++)
                {
                    Console.WriteLine($"{index}: {toppings[index]} ${toppings[index].Price}");
                }
                Console.WriteLine("Input a number for a topping or any other number to quit.");
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
                            if(pizza.Toppings.Count() >= 5)
                            {
                                Console.WriteLine("You've reached your limit on toppings");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unable to add topping.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Thank you for selecting your toppings.");
                        return;
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
