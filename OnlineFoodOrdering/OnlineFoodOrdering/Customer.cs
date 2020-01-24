using System;
namespace OnlineFoodOrdering
{
    public class Customer
    {
        public string FullName
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string Mail
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string Role
        {
            get;
            set;
        }
        public Customer(string fullName,string phoneNumber,string mail,string password,string role)
        {
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.Mail = mail;
            this.Password = password;
            this.Role = role;
        }
    }
}
