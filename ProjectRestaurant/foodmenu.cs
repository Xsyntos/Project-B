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
                double price = 0;
                string Order = "Your Order is ";
                    Console.WriteLine("Please order your food here");
                    Console.WriteLine(@"1)Pasta alla marinara
 : Ham and spicy tomato sauce        Price: 9.50");
                price = 9.50;
                Console.WriteLine(@"2) Pasta salmone 
 : Smoked salmon and cream sauce        Price: 10.50"  );
                price = 10.50;
                Console.WriteLine(@"3) Pasta vegetariana 
 : Vegetables and tomato sauce        Price: 9.50");
                price = 9.50;
                Console.WriteLine(@"4) Pasta quattro formaggi
 : 4 types of cheese and cream sauce        Price: 8.50");
                price = 9.50;
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
