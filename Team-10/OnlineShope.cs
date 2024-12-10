using System;
using System.Collections.Generic;
using System.Linq;

namespace Team10
{
    public class OnlineShop
    {
        // Lists to store categories, products, users, and orders
        private List<Category> categories = new List<Category>();
        private List<Product> products = new List<Product>();
        private List<User> users = new List<User>();
        private Basket basket = new Basket();
        private User loggedInUser;
        private Admin loggedInAdmin;
        private Checkout checkout;

        public OnlineShop()
        {
            loggedInAdmin = null;
            checkout = new Checkout();  // Initialize Checkout
        }

        public void LoadData()
        {
            // Load categories, products, and users (this can be done from a database, file, or hardcoded)
            categories.Add(new Category(1, "Electronics", "Devices and gadgets"));
            categories.Add(new Category(2, "Household", "Household items and appliances"));
            categories.Add(new Category(3, "Clothing", "Clothing for men, women and children"));
            categories.Add(new Category(4, "Books", "Fiction, non-fiction, educational and more"));
            categories.Add(new Category(5, "Toys and Games", "Toys for kids, board games, and puzzles"));

            products.Add(new Product(1, "LED TV", "65 inch Samsung LED TV", 459.99m, 5, 1));
            products.Add(new Product(2, "Vacuum Cleaner", "Dyson V11 Vacuum Cleaner", 599.99m, 10, 2));
            products.Add(new Product(3, "Running Shoes", "Nike Air Zoom Pegasus", 120.00m, 20, 3));
            products.Add(new Product(4, "C# for Beginners", "Learn C# Programming", 12.99m, 25, 4));
            products.Add(new Product(5, "Blender", "NutriBullet Pro", 89.99m, 15, 2));
            products.Add(new Product(6, "Smartphone", "iPhone 13", 999.99m, 8, 5));

            // Example users
            users.Add(new User(1, "john_doe", "password123", "john_doe@email.com", "123 Main St", "Springfield", "SP1 2AB"));
            users.Add(new User(2, "emily_87", "emily2024", "emily_87@email.com", "456 Oak Ave", "Rivertown", "RV3 4CD"));

            // Admin user
            users.Add(new Admin(1, "admin_user", "admin_pass", "admin@email.com", "Admin Address", "Admin City", "12345"));
        }

        // Display Categories to the user
        public void DisplayCategories()
        {
            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId}: {category.CategoryName} - {category.Description}");
            }
        }

        // Display Products to the user
        public void DisplayProducts()
        {
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId}: {product.ProductName} - {product.ProductDescription} - {product.Price:C} - Available: {product.StockQuantity}");
            }
        }

        // Handle User Login
        public void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            loggedInUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (loggedInUser != null)
            {
                Console.WriteLine($"Login successful for {loggedInUser.UserName}");

                // Special check for Admin
                if (loggedInUser is Admin)
                {
                    loggedInAdmin = loggedInUser as Admin;
                    Console.WriteLine("Welcome, Admin! You have access to the Admin Panel.");
                    AdminPanel();  // Direct to the Admin Panel
                }
                else
                {
                    NormalUserPanel(); // Normal user panel
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        // Normal User Panel
        public void NormalUserPanel()
        {
            while (true)
            {
                Console.Clear();
                ShowUserMenu();

                var choice = GetUserInput();

                switch (choice)
                {
                    case "1":
                        DisplayCategories();
                        break;

                    case "2":
                        DisplayProducts();
                        break;

                    case "3":
                        AddProductToBasket();
                        break;

                    case "4":
                        ViewBasket();
                        break;

                    case "5":
                        Checkout();
                        break;

                    case "6":
                        Console.WriteLine("Logging out...");
                        return;  // Return to main menu

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to return to the user menu...");
                Console.ReadKey();
            }
        }

        // Admin Panel to manage tasks
        public void AdminPanel()
        {
            if (loggedInAdmin == null)
            {
                Console.WriteLine("You need to log in as admin first.");
                return;
            }

            while (true)
            {
                Console.Clear();
                ShowAdminMenu();

                var choice = GetUserInput();

                switch (choice)
                {
                    case "1":
                        loggedInAdmin.ManageProducts(products); // Pass the actual product list
                        break;

                    case "2":
                        loggedInAdmin.ManageUsers(users); // Pass the actual user list
                        break;

                    case "3":
                        Console.WriteLine("Exiting the Admin Panel...");
                        return;  // Exit to main menu

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to return to the admin menu...");
                Console.ReadKey();
            }
        }

        // View Basket contents
        public void ViewBasket()
        {
            if (loggedInUser == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            Console.WriteLine($"{loggedInUser.UserName}'s Basket:");
            basket.DisplayBasket();
        }

        // Add Product to Basket
        public void AddProductToBasket()
        {
            if (loggedInUser == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            Console.Write("Enter product ID to add to basket: ");
            int productId;
            if (int.TryParse(Console.ReadLine(), out productId))
            {
                var product = products.FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    if (product.StockQuantity > 0)
                    {
                        basket.AddProduct(product);
                        Console.WriteLine($"{product.ProductName} added to your basket.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, this product is out of stock.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID.");
            }
        }

        // Checkout the basket and complete the order
        public void Checkout()
        {
            if (loggedInUser == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            var order = checkout.ProcessCheckout(loggedInUser, basket.GetProductsInBasket());
            if (order != null)
            {
                Console.WriteLine("Order Summary:");
                order.DisplayOrderDetails();
                basket.ClearBasket();
            }
            else
            {
                Console.WriteLine("There was an issue with your checkout.");
            }
        }

        // Method to show the Admin menu
        private void ShowAdminMenu()
        {
            Console.WriteLine("Welcome to the Admin Panel!");
            Console.WriteLine("1. Manage Products");
            Console.WriteLine("2. Manage Users");
            Console.WriteLine("3. Exit Admin Panel");
            Console.Write("Please select an option: ");
        }

        // Method to show the User menu
        private void ShowUserMenu()
        {
            Console.WriteLine("Welcome to the User Panel!");
            Console.WriteLine("1. Display Categories");
            Console.WriteLine("2. Display Products");
            Console.WriteLine("3. Add Product to Basket");
            Console.WriteLine("4. View Basket");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Logout");
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
