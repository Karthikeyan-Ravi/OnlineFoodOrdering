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
                Console.WriteLine(userchoice.ToString() + "\n");
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
                            Console.WriteLine(customerChoice1.ToString() + "\n");
                        }
                        Console.WriteLine("Enter the customer choice");
                        choice = Console.ReadLine();
                        CustomerChoice customerChoice = (CustomerChoice)Enum.Parse(typeof(CustomerChoice), choice);
                        switch(customerChoice)
                        {
                            case CustomerChoice.SignUp :
                                {
                                    customerRepository.GetSignUpDetails();
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
