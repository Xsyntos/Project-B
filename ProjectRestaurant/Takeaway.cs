using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Takeaway
    {

        public static void Takeawayinput()
        {

            Foodmenu2.Foods1();
            ///foodmenu.Foods(); <--- First Foodmenu
            json_takeaway.takeawayInit();
            
            Console.WriteLine("Insert the Food name: ");
            var Foodname = Console.ReadLine();

            var CostumerName = "";
            if(client_variable.user == null)

            {
                Console.WriteLine("What is your name?: ");
                CostumerName = Console.ReadLine();
            }
            else
            {
                CostumerName = client_variable.user.username;
                Console.WriteLine("Current user logged in: "); 
                Console.WriteLine(CostumerName);
            }
            

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
            json_takeaway.addtakeaway(Foodname, CostumerName, PickUpTime, CardNumber);
            menuReg.mainCustomermenu();
        }
    }
}
