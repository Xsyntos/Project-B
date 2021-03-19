using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Registration
    {
        public static void RegistrationFirstVersion()

        {

            /// Input Username
            Console.WriteLine("Insert Username: ");
            var username = Console.ReadLine();


            {

                /// Input Pasword 
                Console.WriteLine("Insert Password: ");
                var Password = Console.ReadLine();

                /// Input Repeat Pasword 
                Console.WriteLine("Confirm your password: ");
                var repeat = Console.ReadLine();

                /// Warnings 
                if (Password.Length == repeat.Length && Password.Length > 7 && repeat.Length > 7)
                {
                    json_customer.newUser(username, Hash.Encrypt(Password), "123");
                    Console.WriteLine("Successfully registered");
                }
                else
                {
                    Console.WriteLine("Pasword or Username are incorrect, Please try again");
                }

            }


        }
    }
}
