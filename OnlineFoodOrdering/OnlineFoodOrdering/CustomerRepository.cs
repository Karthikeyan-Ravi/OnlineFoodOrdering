using System;
using System.Collections.Generic;
namespace OnlineFoodOrdering
{
    public class CustomerRepository
    {
        string fullName;
        string phoneNumber;
        string mail;
        string password;
        string logInMail;
        string logInPassword;
        public static List<Customer> userDetails = new List<Customer>();
        public void GetSignUpDetails()
        {
            Console.WriteLine("Enter the Name");
            fullName = Validation.GetAndValidateName();
            Console.WriteLine("Enter the mobile number");
            phoneNumber = Validation.GetAndValidatePhoneNumber();
            Console.WriteLine("Enter the mail id");
            mail = Validation.GetAndValidateMail();
            Console.WriteLine("Enter the password");
            password = Validation.GetAndValidatePassword();
            Customer customer = new Customer(fullName, phoneNumber, mail, password,"user");
            userDetails.Add(customer);
            DBUtils dBUtils = new DBUtils();
            //dBUtils.ConnectionMethod();
            dBUtils.AddDetailsToDatabase(userDetails, dBUtils.ConnectionMethod());
            Console.WriteLine("Registration successful");
        }
        public void GetLogInDetails()
        {
            logInMail = Validation.GetLogInMail();
            logInPassword = Validation.GetLogInPassword();
            DBUtils dBUtils = new DBUtils();
            //dBUtils.CheckLogInDetails(logInMail,logInPassword,dBUtils.ConnectionMethod());
            if (dBUtils.CheckLogInDetails(logInMail, logInPassword, dBUtils.ConnectionMethod())== true)
            {
                //Console.WriteLine("Log in successfull");
            }
            else
            {
                //Console.WriteLine("Mailid and password does not match");
                GetLogInDetails();
            }
        }
        
    }

}
