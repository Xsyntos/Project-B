using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class foodmenu
    {
        public static void Foods()
        { 
            
               
                {
                string Order = "Your Order is ";
                    Console.WriteLine("Order a shit to eat");
                    Console.WriteLine(@"1)Pasta Arabiata
 : shit shit shit");
                    Console.WriteLine(@"2) Pasta coze 
 : shit shit shit");
                    Console.WriteLine(@"3) Pasta shit
 : shit poop poop");
                Console.WriteLine(@"4) Pasta damn
 : shit poop poop");
                ConsoleKeyInfo CostumerSelectaFood;
                    CostumerSelectaFood = Console.ReadKey(true);


                    switch (CostumerSelectaFood.KeyChar)
                    {
                        case '1':
                            Console.WriteLine(Order +  "Pasta Arabiata");
                            Console.ReadKey();
                            break;
                        case '2':
                            Console.WriteLine( Order + "Pasta coze ");
                            Console.ReadKey();
                            break;
                    case '3':
                        Console.WriteLine(Order + "Pasta shit");
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.WriteLine(Order + "Pasta damn");
                        Console.ReadKey();
                        break;


                }

            }
            
        }

    }
}
