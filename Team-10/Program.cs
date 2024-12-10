using System;
using System.Collections.Generic;

namespace Team10
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineShop onlineShop = new OnlineShop();

            // Load the initial data (categories, products, users, etc.)
            onlineShop.LoadData();

            while (true)
            {
                Console.Clear();
                ShowMainMenu();

                var choice = GetUserInput();

                switch (choice)
                {
                    case "1":
                        onlineShop.Login();
                        break;

                    case "2":
                        onlineShop.DisplayCategories();
                        break;

                    case "3":
                        onlineShop.DisplayProducts();
                        break;

                    case "4":
                        onlineShop.AddProductToBasket();
                        break;

                    case "5":
                        onlineShop.ViewBasket();
                        break;

                    case "6":
                        onlineShop.Checkout();
                        break;

                    case "7":
                        onlineShop.AdminPanel();
                        break;

                    case "8":
                        Console.WriteLine("Exiting the application...");
                        return;  // Exit the application

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Allow the user to go back to the main menu after completing an option
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        // Method to show the main menu
        static void ShowMainMenu()
        {
            Console.WriteLine("Welcome to the Online Shop!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Display Categories");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Add Product to Basket");
            Console.WriteLine("5. View Basket");
            Console.WriteLine("6. Checkout");
            Console.WriteLine("7. Admin Panel");
            Console.WriteLine("8. Exit");
            Console.Write("Please select an option: ");
        }

        // Method to handle user input and validate it
        static string GetUserInput()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                return string.Empty;
            }

            return input;
        }
    }
}
