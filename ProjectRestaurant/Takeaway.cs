using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Takeaway
    {

        public static void Takeawayinput()
        {

            
            
            json_takeaway.takeawayInit();
            
            Console.WriteLine("Order  your food for take away: ");
            ///foodmenu.Foods(); <--- First Foodmenu
             Foodmenu2.Foods1();
          
            
            
            
            
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
            // json_takeaway.addtakeaway(Foodmenu2, CostumerName, PickUpTime, CardNumber);
            new MenuHandler().userMain();
        }
    }
}
