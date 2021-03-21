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

                }
            }

            if(login <= 0)
            {
                Console.WriteLine("Error");
            }

        }
    }
}
