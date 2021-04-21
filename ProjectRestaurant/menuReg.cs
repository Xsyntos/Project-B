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
                var arr = json_reservation.reservationsofdate(date);
                reservation res = null;

                foreach (var x in arr)
                {
                    if (x.table.Id == table.Id)
                    {
                        res = x;
                    }
                }

                Console.WriteLine("Reservation Complete\n" + "Reservation Code is: " + res.Id);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
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
                    printToConsole = "Check reservations",
                    func = userReservationMenu
                },
                new option
                {
                    printToConsole = "Change account settings"
                },
                new option
                {
                    printToConsole = "Take Away",
                    func = Takeaway.Takeawayinput
                    
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
                   printToConsole = "Check all reservations",
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
        public static void mainCashiermenu()
        {
            
            var x = new option[]
            {
                new option
                {
                    printToConsole = "Check all reservations",

                },
                new option
                {
                    printToConsole = "Change reservation"
                },
                new option
                {
                    printToConsole = "Delete reservation"
                },
                new option
                {
                    printToConsole = "Log- out",
                    func = mainMenu
                }
            };
            var menu = new Menu
            {
                options = x
            };
            menu.RunMenu();
        }


        public static void userReservationMenu() {
            var options = new List<option>();
            foreach (var i in json_reservation.getUserReservations()) {
                options.Add(
                    new option
                    {
                        printToConsole = $"{i.Id} - {i.date}",
                        func = reservationMenu(i)
                    }
                    );

            }
            options.Add(new option { 
                printToConsole = "Return",
                func = mainCustomermenu
            });

            var menu = new Menu
            {
                prefix = "Reservations",
                options = options.ToArray()
            };
            menu.RunMenu();
        }

        public static Action reservationMenu(reservation res) { 
            void rest()
            {
                void cancel()
                {
                    Console.Clear();
                    Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Login  ");
                    Console.WriteLine("WARNING:  If you want to cancel the reservation, you must do so 24 hours in advance, otherwise we will charge you for 10 euros!");
                    Console.WriteLine("To Cancel your Reservation type YES");
                    var x = Console.ReadLine();
                    if (x.ToUpper() == "YES")
                    {
                        json_reservation.removeReservation(res.Id);
                        Console.WriteLine("Your Reservation is succesfully canceled!\nPress a key to Continue");
                        if((res.date - DateTime.Now).Days < 0){
                            Console.WriteLine("We Charged you 10 euros!");
                        }
                        Console.ReadKey();
                        menuReg.mainCustomermenu();
                    }
                    else
                    {
                        Console.WriteLine("Your Reservation is not canceled\nPress a key to Continue");
                        Console.ReadKey();
                        menuReg.mainCustomermenu();
                    }
                }
                var options = new option[]
                {
                    new option
                    {
                        printToConsole = "Cancel Reservation",
                        func = cancel
                    },
                    new option
                    {
                        printToConsole = "Return",
                        func = userReservationMenu
                    }
                };

                var menu = new Menu
                {
                    options = options,
                    prefix = $"Id: {res.Id}\nTable: {res.table.stringy()}\nDate: {res.date}"
                };

                menu.RunMenu();
            }
            return rest;
        }















    }

    

}
