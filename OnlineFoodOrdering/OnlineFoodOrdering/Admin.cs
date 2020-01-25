using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace OnlineFoodOrdering
{
    public class Admin : CustomerAdminFields
    {
        //public List<Admi
        string logInMail;
        string logInPassword;
        public void GetAdminSignUpDetails()
        {
            Console.WriteLine("Enter the Name");
            FullName = Validation.GetAndValidateName();
            Console.WriteLine("Enter the mobile number");
            PhoneNumber = Validation.GetAndValidatePhoneNumber();
            Console.WriteLine("Enter the mail id");
            Mail = Validation.GetAndValidateMail();
            Console.WriteLine("Enter the password");
            Password = Validation.GetAndValidatePassword();
            string query = "Registration";
            //Customer customer = new Customer(fullName, phoneNumber, mail, password, "admin");
            //userDetails.Add(customer);
            DBUtils dBUtils = new DBUtils();
            SqlConnection sqlConnection = dBUtils.ConnectionMethod();
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.Parameters.AddWithValue("@FullName", FullName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Mail", Mail);
                sqlCommand.Parameters.AddWithValue("@Password", Password);
                sqlCommand.Parameters.AddWithValue("@Role", "Admin");
                sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows >= 1)
                    Console.WriteLine("Registration successfull");
                else
                {
                    Console.WriteLine("Registration not successfull");
                    GetAdminSignUpDetails();
                }
            }
            //dBUtils.ConnectionMethod();
            //dBUtils.AddDetailsToDatabase(userDetails, dBUtils.ConnectionMethod());
            //Console.WriteLine("Registration successful");
        }
        public void GetAdminLogInDetails()
        { 
            logInMail = Validation.GetLogInMail();
            logInPassword = Validation.GetLogInPassword();
            DBUtils dBUtils = new DBUtils();
            dBUtils.CheckLogInDetails(logInMail,logInPassword,dBUtils.ConnectionMethod());
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
