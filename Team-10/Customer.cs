namespace Team10
{
    public class Customer : User
    {
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }

        // Constructor for Customer
        public Customer(int userId, string userName, string password, string email, string? shippingAddress, string? billingAddress,
                        string address, string city, string postcode, string? phoneNumber = null) 
            : base(userId, userName, password, email, address, city, postcode, phoneNumber)
        {
            ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
            BillingAddress = billingAddress ?? throw new ArgumentNullException(nameof(billingAddress));
        }


        // Method to update the customer's address
        public void UpdateAddress(string billingAddress, string shippingAddress)
        {
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Console.WriteLine("Your address has been updated.");
        }
    }
}
