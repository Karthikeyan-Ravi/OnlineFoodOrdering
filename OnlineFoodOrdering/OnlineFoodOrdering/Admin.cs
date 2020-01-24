using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace OnlineFoodOrdering
{
    public class Admin : CustomerRepository
    {
        //public List<Admin> items = new List<Admin>();
        string fullName;
        string phoneNumber;
        string mail;
        string password;
        string logInMail;
        string logInPassword;
        static Admin()
        {
            //AddAdminDetails();
        }
        public void GetAdminSignUpDetails()
        {
            Console.WriteLine("Enter the Name");
            fullName = Validation.GetAndValidateName();
            Console.WriteLine("Enter the mobile number");
            phoneNumber = Validation.GetAndValidatePhoneNumber();
            Console.WriteLine("Enter the mail id");
            mail = Validation.GetAndValidateMail();
            Console.WriteLine("Enter the password");
            password = Validation.GetAndValidatePassword();
            Customer customer = new Customer(fullName, phoneNumber, mail, password, "admin");
            userDetails.Add(customer);
            DBUtils dBUtils = new DBUtils();
            //dBUtils.ConnectionMethod();
            dBUtils.AddDetailsToDatabase(userDetails, dBUtils.ConnectionMethod());
            Console.WriteLine("Registration successful");
        }
        public void GetAdminLogInDetails()
        {
            logInMail = Validation.GetLogInMail();
            logInPassword = Validation.GetLogInPassword();
            DBUtils dBUtils = new DBUtils();
            //dBUtils.CheckLogInDetails(logInMail,logInPassword,dBUtils.ConnectionMethod());
            if (dBUtils.CheckLogInDetails(logInMail, logInPassword, dBUtils.ConnectionMethod()) == true)
            {
                //Console.WriteLine("Log in successfull");
            }
            else
            {
                //Console.WriteLine("Mailid and password does not match");
                GetAdminLogInDetails();
            }

        }
    }
}
