using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{

    class login

    {
        public static void Login()
        {
            // login

            int login = 0;


            string username;
            string password;

            var users = json_customer.getUserlist();
            
            
            while (login == 0)
            {
                Console.WriteLine("Please enter your username: ");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                foreach (var x in users)
                {
                    if (username == x.username && Hash.Encrypt(password) == x.password)
                    {
                        Console.WriteLine("Log in successful!");
                        login += 1;
                        client_variable.user = x;
                        if (x.role == "customer")
                        {
                            menuReg.mainCustomermenu();
                        }
                        if (x.role == "admin")
                        {
                            menuReg.mainAdminmenu();
                        }

                    }
                }
                Console.WriteLine("Error");
            }
        }
    }
}
