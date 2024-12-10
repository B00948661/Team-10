namespace Team10
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }

        public Product(int productId, string productName, string productDescription, decimal price, int stockQuantity, int categoryId)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }
    }
}
