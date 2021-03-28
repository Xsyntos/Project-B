using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class menuReg
    {
        //Reservation menu
        
        public static Action reservationMenu1(int y)
        {

            void resv() { 
            var list = new List<option>();
            for (int i = 1; i <= 7; i++)
                {
                    list.Add(new option
                    {
                        printToConsole = $"{DateTime.Now.AddDays((double)i + (y * 7)).Day}-{DateTime.Now.AddDays((double)i + (y * 7)).Month}-{DateTime.Now.AddDays((double)i + (y * 7)).Year}, 12 PM",
                        func = reservationMenuDay(new DateTime(DateTime.Now.AddDays((double)i + (y * 7)).Year, DateTime.Now.AddDays((double)i + (y * 7)).Month, DateTime.Now.AddDays((double)i + (y * 7)).Day, 12, 0, 0))
                    }
                    );
                    list.Add(new option
                    {
                        printToConsole = $"{DateTime.Now.AddDays((double)i + (y * 7)).Day}-{DateTime.Now.AddDays((double)i + (y * 7)).Month}-{DateTime.Now.AddDays((double)i + (y * 7)).Year}, 6 PM",
                        func = reservationMenuDay(new DateTime(DateTime.Now.AddDays((double)i + (y * 7)).Year, DateTime.Now.AddDays((double)i + (y * 7)).Month, DateTime.Now.AddDays((double)i + (y * 7)).Day, 18, 0, 0))
                    }
            

    // TO DO: ga terug knop
    );
            }
                list.Add(new option
                {
                    printToConsole = "Next Week",
                    func = reservationMenu1(y + 1)
                });

                if(y > 0)
                {
                    list.Add(new option
                    {
                        printToConsole = "Previous Week",
                        func = reservationMenu1(y - 1)
                    });
                }
                list.Add(new option
                {
                    printToConsole = "Return",
                    func = mainCustomermenu
                });

            Menu menu = new Menu
            {
                options = list.ToArray(),
                prefix = "Select a Date"
            };
            menu.RunMenu();
        }
            return resv;
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
                option.Add(new option
                {
                    printToConsole = "Return",
                    func = reservationMenu1(0)
                });
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
                mainCustomermenu();
            }
            return MakeReservationMenu;
        }
        // Next menu:
        public static void mainMenu()
        {
            var optie = new option[] {
                new option
                {
                    printToConsole = "Log-in",
                    func = login.Login
                },
                new option
                {
                    printToConsole =  "Registrate" ,
                    func = Registration.RegistrationFirstVersion
                },
                new option
                {
                    printToConsole = "Log-in as Guest"
                },
                new option
                {
                    printToConsole = "Quit"
                }
            };
            var menu = new Menu
            {
                options = optie,
                prefix = "Welcome to our Restaurant"
            };
            menu.RunMenu();
        }
        public static void mainCustomermenu()
        {
            var optie = new option[]
            {
                new option
                {
                    printToConsole = "Make a Reservation",
                    func = reservationMenu1(0)
                },
                new option
                {
                    printToConsole = "Check reservations"
                },
                new option
                {
                    printToConsole = "Change account settings"
                },
                new option
                {
                    printToConsole = "Log-out",
                    func = mainMenu
                }

            };
            var menu = new Menu
            {
                prefix = "Welcome to our Restaurant",
                options = optie
            };
            menu.RunMenu();
        }
        public static void mainAdminmenu()
        {
            var x = new option[]
            {
               new option
               {
                   printToConsole = "Check all reservations"
               },
               new option
               {
                   printToConsole = "Tables"
               },
               new option
               {
                   printToConsole = "Log-out",
                   func = mainMenu
               }

        
            };
            var menu = new Menu
            {
                prefix = "Welcome Boss",
                options = x
            };
            menu.RunMenu();

        }


    }

    

}
