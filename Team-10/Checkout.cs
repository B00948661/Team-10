namespace Team10
{
    public class Checkout
    {
        public Order ProcessCheckout(User user, List<Product> productsInBasket)
        {
            if (productsInBasket.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
                return null;
            }

            // Add logic for processing the checkout
            Console.WriteLine("Processing checkout...");
            return new Order(1, user, productsInBasket);  // Example: Creating an order
        }
    }
}
