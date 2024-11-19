using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_10
{
    internal class User
    {
        private int userID;
        private string userName;
        private string password;
        private string userEmail;
        private int phoneNumber;
        private string street;
        private string city;
        private string postcode;

        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public string UserEmail { get; private set; }

        public int PhoneNumber { get; private set; }

        public string Street { get; private set; }

        public string City { get; private set; }

        public string Postcode { get; private set; }

        public User(int shopUserID, string shopUserName, string shopPassword, string shopUserEmail, int shopPhoneNumber, string shopStreet, string shopCity, string shopPostcode)
        {
            this.UserID = shopUserID;
            this.UserName = shopUserName;
            this.Password = shopPassword;
            this.UserEmail = shopUserEmail;
            this.PhoneNumber = shopPhoneNumber;
            this.Street = shopStreet;
            this.City = shopCity;
            this.Postcode = shopPostcode;

        }

        public static void UpdateProfile()
        {

        }

        public static void LogOut()
        {

        }

    }
}
