using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Foodmenu2
    {

        public static void Foods1()
        {
                double TotalFoodCost = 0;

            Start:
                Console.WriteLine(@"Please order your food here :
1 - Pasta alla marinara:
--Ham and spicy tomato sauce        Price: 9.50 
2 - Pasta salmone : 
--Smoked salmon and cream sauce        Price: 10.50
3 - Pasta vegetariana: 
--Vegetables and tomato sauce        Price: 9.50 ");
                int UserChoise = int.Parse(Console.ReadLine());

                switch (UserChoise)
                {
                    case 1:
                    TotalFoodCost += 9.50;  //Food Price
                        break;
                    case 2:
                    TotalFoodCost += 10.50;  //Food Price
                        break;
                    case 3:
                    TotalFoodCost += 9.50;  //Food Price
                        break;
                    default:
                        Console.WriteLine("Your choise {0} is invaid us", UserChoise);
                        goto Start;
                }

            Decide:
                Console.WriteLine("Do you orde another Food - YES or NO?");
                string UserDessition = Console.ReadLine();

                switch (UserDessition.ToUpper())
                {
                    case "YES":
                        goto Start;
                    case "NO":
                        break;
                    default:
                        Console.WriteLine("Your Choise {0} is invalid, please try again.");
                        goto Decide;

                }

               /// Console.WriteLine("Thanks you for Order food.");
                Console.WriteLine("Your Bill Amount = {0} Please press Enter to pay", TotalFoodCost);

                Console.ReadLine();
            }
        }
    }

