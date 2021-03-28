using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Takeaway
    {

        public static void Takeawayinput()
        {
            
            Console.WriteLine("Insert the Food name: ");
            var Foodname = Console.ReadLine();
            {
                ///Costumer Name
                Console.WriteLine("What is your name?: ");
                var CostumerNmae = Console.ReadLine();

                /// Time to pick up
                Console.WriteLine("when do you want to pick up your food? : ");
                var PickUpTime = Console.ReadLine();

                /// Credit card
                String CardNumber1 = "12345678900000";
                Console.WriteLine("Put your card number: ");
                var CardNumber = Console.ReadLine();

                if(CardNumber.Length < CardNumber1.Length)
                {
                    Console.WriteLine("Credit card number is Invalid Try again pleas");
                } else
                {
                    Console.WriteLine("Successfully paid ");
                }
            }
        }
    }
}
