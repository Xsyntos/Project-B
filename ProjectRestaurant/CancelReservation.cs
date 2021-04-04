using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class CancelReservation
    {
        public static void CanceltheReservation()
        {
            json_reservation.reservationInit();
            var CostumerName = "";
            if (client_variable.user == null)

            {
                Console.WriteLine("What is your name?: ");
                CostumerName = Console.ReadLine();
            }
            else
            {
                CostumerName = client_variable.user.username;
                Console.WriteLine("Your User Name is: ");
                Console.WriteLine(CostumerName);
            }
            Start: 
            Console.WriteLine(@"Warning : If you want to cancel the reservation, you must do so 24 hours in advance,
otherwise we will charge you for 10 euros
Write 1 to Cancel all of your Reservation/s .");



            int CancelTheReservation1 = int.Parse(Console.ReadLine());
            switch (CancelTheReservation1)
            {
                case 1:
                    Console.WriteLine("already canceled");
                    break;
                default:
                    Console.WriteLine("Your choise {0} is invaid, please try again", CancelTheReservation1);
                    goto Start;
            }
        }
    }

}

