using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
                        new MenuHandler().userMain();
                    }
                    else
                    {
                        Console.WriteLine("\nWrong credentials. Press Enter to continue...");
                        Console.ReadKey();
                        new MenuHandler().mainMenu();
                    }
                }
                Console.WriteLine("Error");
                Console.ReadKey();
                new MenuHandler().mainMenu();


            }
        }
    }
}
