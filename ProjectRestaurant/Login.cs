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
            Console.Clear();
            Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Login  ");
            int login = 0;

            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();


            var users = json_customer.getUserlist();
            foreach(var x in users)
            {
                if(username == x.username && Hash.Encrypt(password) == x.password)
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

            if(login <= 0)
            {
                Console.WriteLine("Error");
                Console.ReadKey();
                menuReg.mainMenu();
            }

        }
    }
}
