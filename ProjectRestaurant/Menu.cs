using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Menu
    {
        public static void MainMenu()
        {



           
            Console.WriteLine("[1] Log-In");
            Console.WriteLine("[2] Sign-Up");
            Console.WriteLine("[3] Continue as guest");
            Console.WriteLine("[4] Exit");

            string input = Console.ReadLine();

            if (input == "1")
            {
                ///Log in
            }
            else if (input == "2")
            {

                 Registration.RegistrationFirstVersion();

            }
            else if (input == "3")
            {
                Guest.LoginAsGuest();

            }
            else
            {
                Console.WriteLine("Thank you for visiting our restaurant application, See You Soon ");
                Environment.Exit(0);
            }


               }

           }
        }

     
    
