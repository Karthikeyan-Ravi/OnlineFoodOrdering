using System;
namespace OnlineFoodOrdering
{
    public class Portal
    {
        enum UserChoice
        {
                customer,
                admin,
                exit
        };
        enum CustomerChoice
        {
            SignUp,
            LogIn
        };
        public void GetUserChoice()
        {
            
            foreach(UserChoice userchoice in Enum.GetValues(typeof(UserChoice)))
            {
                Console.WriteLine("\n"+userchoice.ToString() + "\n");
            }
            Console.WriteLine("Enter the choice");
            string choice = Console.ReadLine();
            UserChoice userChoice = (UserChoice)Enum.Parse(typeof(UserChoice), choice);
            switch(userChoice)
            {
                case UserChoice.customer:
                    {
                        CustomerRepository customerRepository = new CustomerRepository();
                        foreach(CustomerChoice customerChoice1 in Enum.GetValues(typeof(CustomerChoice)))
                        {
                            Console.WriteLine("\n" + customerChoice1.ToString() + "\n");
                        }
                        Console.WriteLine("\n"+"Enter the customer choice"+ "\n" );
                        choice = Console.ReadLine();
                        CustomerChoice customerChoice = (CustomerChoice)Enum.Parse(typeof(CustomerChoice), choice);
                        switch(customerChoice)
                        {
                            case CustomerChoice.SignUp :
                                {
                                    customerRepository.GetSignUpDetails();
                                    //customerRepository.GetLogInDetails();
                                }
                                break;
                            case CustomerChoice.LogIn:
                                {
                                    customerRepository.GetLogInDetails();
                                }break;
                        }
                    }break;
                case UserChoice.admin:
                    {
                        Admin admin = new Admin();
                        foreach (CustomerChoice customerChoice1 in Enum.GetValues(typeof(CustomerChoice)))
                        {
                            Console.WriteLine(customerChoice1.ToString() + "\n");
                        }
                        Console.WriteLine("Enter the customer choice");
                        choice = Console.ReadLine();
                        CustomerChoice customerChoice = (CustomerChoice)Enum.Parse(typeof(CustomerChoice), choice);
                        switch (customerChoice)
                        {
                            case CustomerChoice.SignUp:
                                {
                                    admin.GetAdminSignUpDetails();
                                    //admin.GetAdminLogInDetails();
                                }
                                break;
                            case CustomerChoice.LogIn:
                                {
                                    admin.GetAdminLogInDetails();
                                }
                                break;
                        }

                    }
                    break;
                case UserChoice.exit:
                    {

                    }break;
            }
        }
    }
   
}
