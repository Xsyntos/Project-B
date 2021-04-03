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
            
            if(client_variable.user == null)
            {
                Console.WriteLine("What is your name?: ");
                var CostumerName = Console.ReadLine();
            }
            else
            {
                var CostumerName = client_variable.user.username;
                Console.WriteLine("Current user logged in: "); 
                Console.WriteLine(CostumerName);
            }
            ///Costumer Name
            

            /// Time to pick up
            Console.WriteLine("when do you want to pick up your food? : ");
            var PickUpTime = Console.ReadLine();

            /// Credit card
            
            Console.WriteLine("Put your card number: ");
            var CardNumber = Console.ReadLine();

            while (!Checker.Check(CardNumber))
            {
                Console.WriteLine("Credit card number is Invalid! Please try again.");
                CardNumber = Console.ReadLine();
            }
            menuReg.mainCustomermenu();
        }
    }
}
