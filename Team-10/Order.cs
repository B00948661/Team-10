namespace Team10
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }

        public Order(int orderId, User user, List<Product> products)
        {
            OrderId = orderId;
            User = user;
            Products = products;
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {User.UserName}");
            Console.WriteLine("Products in your order:");
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.ProductName} - {product.Price:C}");
            }
        }
    }
}
