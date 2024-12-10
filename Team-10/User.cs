public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }  // Nullable string
    public string? City { get; set; }     // Nullable string

    public string Postcode { get; set; }
    public string? PhoneNumber { get; set; }

    // Constructor with 8 parameters
    public User(int userId, string userName, string password, string email, string address, string city, string postcode, string? phoneNumber = null)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
        Email = email;
        Address = address;
        City = city;
        Postcode = postcode;
        PhoneNumber = phoneNumber;
    }
}
