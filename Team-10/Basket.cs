namespace Team10
{
    public class Basket
    {
        private List<Product> productsInBasket = new List<Product>();

        public void AddProduct(Product product)
        {
            productsInBasket.Add(product);
        }

        public void ClearBasket()
        {
            productsInBasket.Clear();
        }

        public List<Product> GetProductsInBasket()
        {
            return productsInBasket;
        }

        public void DisplayBasket()
        {
            foreach (var product in productsInBasket)
            {
                Console.WriteLine($"{product.ProductName} - {product.Price:C} - Quantity: {product.StockQuantity}");
            }
        }
    }
}
