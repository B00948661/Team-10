using System;
using System.Collections.Generic;
using System.Linq;

namespace Team10
{
    // Admin inherits from User
    public class Admin : User
    {
        // Constructor that calls the base User class constructor
        public Admin(int userId, string userName, string password, string email, string? address = null, string? city = null, string? postcode = null)
            : base(userId, userName, password, email, address, city, postcode)
        {
        }

        // Manage Products - logic to manage products (add, update, delete, etc.)
        public void ManageProducts(List<Product> products)
        {
            Console.WriteLine("Managing Products...");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.Write("Choose an option: ");
            
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddProduct(products);
                        break;
                    case 2:
                        UpdateProduct(products);
                        break;
                    case 3:
                        DeleteProduct(products);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        // Manage Users - logic to manage users (add, update, delete, etc.)
        public void ManageUsers(List<User> users)
        {
            Console.WriteLine("Managing Users...");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.Write("Choose an option: ");
            
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddUser(users);
                        break;
                    case 2:
                        UpdateUser(users);
                        break;
                    case 3:
                        DeleteUser(users);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        // Method to add a product
        private void AddProduct(List<Product> products)
        {
            Console.WriteLine("Enter product details to add:");

            Console.Write("Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Product Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Stock Quantity: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Category Id: ");
            int categoryId = int.Parse(Console.ReadLine());

            int productId = products.Count + 1;  // Generate a new product ID

            Product newProduct = new Product(productId, name, description, price, stock, categoryId);
            products.Add(newProduct);

            Console.WriteLine("Product added successfully!");
        }

        // Method to update a product
        private void UpdateProduct(List<Product> products)
        {
            Console.Write("Enter the product ID to update: ");
            int productId = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                Console.WriteLine("Enter new details for the product:");
                Console.Write("Product Name: ");
                product.ProductName = Console.ReadLine();
                Console.Write("Product Description: ");
                product.ProductDescription = Console.ReadLine();
                Console.Write("Price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Stock Quantity: ");
                product.StockQuantity = int.Parse(Console.ReadLine());
                Console.Write("Category Id: ");
                product.CategoryId = int.Parse(Console.ReadLine());

                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Method to delete a product
        private void DeleteProduct(List<Product> products)
        {
            Console.Write("Enter the product ID to delete: ");
            int productId = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Method to add a user
        private void AddUser(List<User> users)
        {
            Console.WriteLine("Enter user details to add:");

            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Postcode: ");
            string postcode = Console.ReadLine();

            int userId = users.Count + 1;  // Generate a new user ID

            User newUser = new User(userId, userName, password, email, address, city, postcode);
            users.Add(newUser);

            Console.WriteLine("User added successfully!");
        }

        // Method to update a user
        private void UpdateUser(List<User> users)
        {
            Console.Write("Enter the user ID to update: ");
            int userId = int.Parse(Console.ReadLine());
            var user = users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                Console.WriteLine("Enter new details for the user:");
                Console.Write("User Name: ");
                user.UserName = Console.ReadLine();
                Console.Write("Password: ");
                user.Password = Console.ReadLine();
                Console.Write("Email: ");
                user.Email = Console.ReadLine();
                Console.Write("Address: ");
                user.Address = Console.ReadLine();
                Console.Write("City: ");
                user.City = Console.ReadLine();
                Console.Write("Postcode: ");
                user.Postcode = Console.ReadLine();

                Console.WriteLine("User updated successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to delete a user
        private void DeleteUser(List<User> users)
        {
            Console.Write("Enter the user ID to delete: ");
            int userId = int.Parse(Console.ReadLine());
            var user = users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
