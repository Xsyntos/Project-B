using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class menu
    {
        public static void Login()
        {
            // login
            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();

            //Need JSON FILE to check username and pass
            /*if (username == ... && password == ...) {
                Console.WriteLine("Succesfuly logged in");
            else
                {
                    Console.WriteLine("Wrong login/password. Try again");
                }
            */
        }
    }
}
