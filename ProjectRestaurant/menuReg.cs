using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class menuReg
    {
        //Reservation menu
        public static void reservationMenu1()
        {

            var list = new List<option>();
                for(int i = 1; i <=14; i++)
            {
                list.Add(new option {
                    printToConsole = $"{DateTime.Now.AddDays((double)i).Day}-{DateTime.Now.AddDays((double)i).Month}-{DateTime.Now.AddDays((double)i).Year}, 12 PM",
                    func = reservationMenuDay(new DateTime(DateTime.Now.AddDays((double)i).Year, DateTime.Now.AddDays((double)i).Month, DateTime.Now.AddDays((double)i).Day, 12, 0, 0))
                }
                );
                list.Add(new option
                {
                    printToConsole = $"{DateTime.Now.AddDays((double)i).Day}-{DateTime.Now.AddDays((double)i).Month}-{DateTime.Now.AddDays((double)i).Year}, 6 PM",
                    func = reservationMenuDay(new DateTime(DateTime.Now.AddDays((double)i).Year, DateTime.Now.AddDays((double)i).Month, DateTime.Now.AddDays((double)i).Day, 18, 0, 0))
                }

                // TO DO: ga terug knop
);      
            }

            Menu menu = new Menu
            {
                options = list.ToArray(),
                prefix = "Select a Date"
            };
            menu.RunMenu();
        }
        public static Action reservationMenuDay(DateTime i)
        {
            var date = i; 
            void reservationMenu2()
            {
                var availabletables = json_table.getFreeTable(date);
                var option = new List<option>();
                foreach (var i in availabletables)
                {
                    if (i.vip)
                    {
                        option.Add(new option
                        {
                            printToConsole = $"{i.Id}. {i.capacity} persons VIP",
                            func = makeReservationMenu(date, i)
                        }
                        );
                    }
                    else
                    {
                        option.Add(new option
                        {
                            printToConsole = $"{i.Id}. {i.capacity} persons",
                            func = makeReservationMenu(date, i)
                        }
                        );
                    }
                }
                Menu menu = new Menu
                {
                    options = option.ToArray(),
                    prefix = "Select a Table"
                    
                };
                
                menu.RunMenu();
            }
            return reservationMenu2;
        }
        public static Action makeReservationMenu(DateTime date, table table)
        {
            void MakeReservationMenu()
            {
                json_reservation.makeReservation(date, client_variable.user, table);
            }
            return MakeReservationMenu;
        }
        // Next menu:



    }

    

}
