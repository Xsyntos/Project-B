using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ProjectRestaurant
{
    class MenuHandler
    {
        protected GeneralMenus general;
        protected AdminMenus admin;
        protected ChefMenus chef;
        protected CashierMenus cashier;
        protected CustomerMenus customer;
        protected GuestMenus guest;

        protected class GeneralMenus
        {
            public void mainMenu()
            {
                client_variable.user = null;
                {

                };
                void loginGuest()
                {
                    client_variable.user = new user()
                    {
                        role = "guest"
                    };

                    new MenuHandler().userMain();
                }

                var optie = new option[] {
                new option
                {
                    printToConsole = "Log-in",
                    func = login.Login
                },
                new option
                {
                    printToConsole =  "Register" ,
                    func = Registration.RegistrationFirstVersion
                },
                new option
                {
                    printToConsole = "Log-in as Guest",
                    func = loginGuest
                },
                new option
                {
                    printToConsole = "Quit",
                    func = close
                }
            };
                void close() {
                    for(int i = 0; i < 3; i++)
                    {
                        Console.Beep();
                    }


                    System.Environment.Exit(1); }
                var menu = new Menu
                {
                    options = optie,
                    prefix = "Welcome to our Restaurant"
                };
                menu.RunMenu();
            }
            private void Main()
            {

            }

            public Action reservationMenu(reservation res)
            {
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
                                           
Cancel Reservation  ");
                        Console.WriteLine("WARNING:  If you want to cancel the reservation, you must do so 24 hours in advance, otherwise we will charge you for 10 euros!");
                        Console.WriteLine("To Cancel your Reservation type YES");
                        var x = Console.ReadLine();
                        if (x.ToUpper() == "YES")
                        {
                            json_reservation.removeReservation(res.Id);
                            Console.WriteLine("Your Reservation is succesfully canceled!\nPress a key to Continue");
                            if ((res.date - DateTime.Now).Days < 0)
                            {
                                Console.WriteLine("We Charged you 10 euros!");
                            }
                            Console.ReadKey();
                            new MenuHandler().userMain();
                        }
                        else
                        {
                            Console.WriteLine("Your Reservation is not canceled\nPress a key to Continue");
                            Console.ReadKey();
                            new MenuHandler().userMain();

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
                        func = new MenuHandler().userMain
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

            public void accountSettings()
            {
                void changeUsername()
                {
                    Console.Clear();
                    Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Change Username  ");
                    Console.WriteLine("Enter your old username");
                    string oldusername = Console.ReadLine();
                    if (oldusername == client_variable.user.username)
                    {
                        Console.WriteLine("Enter your new username");
                        string newusername = Console.ReadLine();
                        Console.WriteLine("Confirm your new username");
                        string newusername2 = Console.ReadLine();
                        if (newusername == newusername2)
                        {
                            client_variable.user.username = newusername;
                            json_customer.updateUserFromClient();
                            accountSettings();
                        }
                        else
                        {
                            Console.WriteLine("Usernames are not the same!\nPress a Key to continue...");
                            Console.ReadKey();
                            accountSettings();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username!\nPress a Key to continue...");
                        Console.ReadKey();
                        accountSettings();
                    }
                }
                void changePassword()
                {
                    Console.Clear();
                    Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Change password  ");
                    Console.WriteLine("Enter your old password");
                    string oldusername = Console.ReadLine();
                    if (Hash.Encrypt(oldusername) == client_variable.user.password)
                    {
                        Console.WriteLine("Enter your new password");
                        string newusername = Console.ReadLine();
                        Console.WriteLine("Confirm your new password");
                        string newusername2 = Console.ReadLine();
                        if (newusername == newusername2)
                        {
                            client_variable.user.password = Hash.Encrypt(newusername);
                            json_customer.updateUserFromClient();
                            accountSettings();
                        }
                        else
                        {
                            Console.WriteLine("Passwords are not the same!\nPress a Key to continue...");
                            Console.ReadKey();
                            accountSettings();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password!\nPress a Key to continue...");
                        Console.ReadKey();
                        accountSettings();
                    }


                }
                void changeCreditcard()
                {
                    Console.Clear();
                    Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Change Creditcard  ");

                    string oldusername = "123";
                    if (!(client_variable.user.creditcard == "123"))
                    {
                        Console.WriteLine("Enter your old creditcard");
                        oldusername = Console.ReadLine();
                    }
                    if (oldusername == client_variable.user.creditcard)
                    {
                        Console.WriteLine("Enter your new creditcard");
                        string newusername = Console.ReadLine();
                        if (!Checker.Check(newusername))
                        {
                            Console.WriteLine("Invalid Creditcard!\nPress a Key to continue...");
                            Console.ReadKey();
                            accountSettings();
                        }
                        Console.WriteLine("Confirm your new creditcard");
                        string newusername2 = Console.ReadLine();
                        if (newusername == newusername2)
                        {
                            client_variable.user.creditcard = newusername;
                            json_customer.updateUserFromClient();
                            accountSettings();
                        }
                        else
                        {
                            Console.WriteLine("Creditcards are not the same!\nPress a Key to continue...");
                            Console.ReadKey();
                            accountSettings();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid creditcard!\nPress a Key to continue...");
                        Console.ReadKey();
                        accountSettings();
                    }
                }

                option[] options = new option[]
                {
                new option()
                {
                    printToConsole = "Change Username",
                    func = changeUsername
                },
                new option()
                {
                    printToConsole = "Change Password",
                    func = changePassword
                },
                new option()
                {
                    printToConsole = "Change Creditcard",
                    func = changeCreditcard
                },
                new option()
                {
                    printToConsole = "Return",
                    func = new MenuHandler().userMain
                }
                };

                Menu men = new Menu()
                {
                    options = options,
                    prefix = "Change Account Settings"
                };
                men.RunMenu();
            }



        }
        protected class AdminMenus : ChefMenus
        {
            public void Main()
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
                   printToConsole = "Change Account settings",
                   func = accountSettings
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
        protected class ChefMenus : GeneralMenus
        {
            public void Main()
            {
                var x = new option[]
                {
                   new option
                   {
                       printToConsole = "Add a Dish",
                       func = addDishes
                   },
                   new option
                   {
                       printToConsole = "Update a Dish",
                       func = getAllDishes

                   },
                   new option
                   {
                       printToConsole = "Delete a Dish",
                       func = deleteDishes
                   },
                   new option
                   {
                       printToConsole = "Log-out",
                       func = mainMenu
                   }
                };
                var menu = new Menu
                {
                    prefix = "Welcome Chef",
                    options = x
                };
                menu.RunMenu();
            }

            private void getAllDishes()
            {
                var x = new option[json_dish.getDishList().Count];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = new option
                    {
                        printToConsole = $"{json_dish.getDishList()[i].Title}",
                        func = listSettingsDish(json_dish.getDishList()[i])
                    };
                }
                var menu = new Menu
                {
                    prefix = "Welcome Chef",
                    options = x
                };
                menu.RunMenu();

            }

            private void addDishes()
            {
                Console.WriteLine("What is the name of the dish:");
                string name = Console.ReadLine();
                Console.WriteLine("What is the price of the dish:");
                var price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Add a description here:");
                string description = Console.ReadLine();
                Dish dish = new Dish()
                    {
                        Title = name,
                        Price = (float)price,
                        Description = description,
                        Spotlighted = false,
                        Categories = new List<string>(),
                        Stock = 0
                };
                json_dish.addDish(dish)();
                Main();
            }

            private Action listSettingsDish(Dish dish)
            {
                void tes()
                {
                    var option = new List<option>();
                    option.Add(new option()
                    {
                        printToConsole = "Title",
                        func = updateDish(dish, 1)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Price",
                        func = updateDish(dish, 2)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Description",
                        func = updateDish(dish, 3)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Spotlighted",
                        func = updateDish(dish, 4)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Categories",
                        func = updateDish(dish, 5)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Stock",
                        func = updateDish(dish, 6)
                    });

                    Menu menu = new Menu
                    {
                        options = option.ToArray(),
                        prefix = "Select an option"
                    };
                    menu.RunMenu();
                }
                return tes;
            } 
            private Action updateDish(Dish dish, int num)
            {
                void tes()
                {
                    json_dish.update(dish, num)();
                    Main();
                }
                return tes;
            }
            private void deleteDishes()
            {
                var x = new option[json_dish.getDishList().Count];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = new option
                    {
                        printToConsole = $"{json_dish.getDishList()[i].Title}",
                        func = deleteDish(json_dish.getDishList()[i].UID)
                    };
                }
                var menu = new Menu
                {
                    prefix = "Welcome Chef, what dish do you want to be removed?",
                    options = x
                };
                menu.RunMenu();
            }

            private Action deleteDish(int id)
            {
                void tes()
                {
                    json_dish.removeDish(id)();
                    Main();

                }
                return tes;
            }
        }

        protected class CashierMenus : GeneralMenus
        {
            public void Main()
            {

                var x = new option[]
                {
                new option
                {
                    printToConsole = "Reservation Menu",
                    func = cashierReservationMenu
                },
                new option
                {
                    printToConsole = "Change Account Settings",
                    func = accountSettings
                },
                new option
                {
                    printToConsole = "Log-out",
                    func = mainMenu
                }
                };
                var menu = new Menu
                {
                    options = x,
                    prefix = "Welcome Cashier"
                };
                menu.RunMenu();
            }

            private void cashierReservationMenu()
            {
                var options = new List<option>();
                string jsonString = File.ReadAllText(@"reservation.json");
                var data = JsonSerializer.Deserialize<System.Collections.Generic.List<reservation>>(jsonString);
                foreach (var i in data)
                {
                    options.Add(
                        new option
                        {
                            printToConsole = $"{i.Id} - {i.date}",
                            func = reservationMenu(i)
                        }
                        );

                }
                options.Add(new option
                {
                    printToConsole = "Return",
                    func = this.Main
                });

                var menu = new Menu
                {
                    prefix = "Reservations",
                    options = options.ToArray()
                };
                menu.RunMenu();
            }



        }
        protected class CustomerMenus : GeneralMenus
        {
            //menu
            protected void Catagory()
            {
                bool isInCat(string s)
                {
                    return client_variable.dish_catagory.ToArray().Intersect(new string[] {s }).Any();
            }
                
                var opties = new option[]
                {
                    new option
                    {
                        printToConsole = $"Children Food <{isInCat("childrenfood")}>",
                        func = () =>
                        {
                            if (isInCat("childrenfood"))
                            {
                                client_variable.dish_catagory.Remove("childrenfood");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("childrenfood");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Vegan <{isInCat("vegan")}>",
                        func = () =>
                        {
                            if (isInCat("vegan"))
                            {
                                client_variable.dish_catagory.Remove("vegan");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("vegan");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Meat <{isInCat("meat")}>",
                        func = () =>
                        {
                            if (isInCat("meat"))
                            {
                                client_variable.dish_catagory.Remove("meat");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("meat");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Lunch <{isInCat("lunch")}>",
                        func = () =>
                        {
                            if (isInCat("lunch"))
                            {
                                client_variable.dish_catagory.Remove("lunch");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("lunch");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Dinner <{isInCat("dinner")}>",
                        func = () =>
                        {
                            if (isInCat("dinner"))
                            {
                                client_variable.dish_catagory.Remove("dinner");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("dinner");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Turkish Food <{isInCat("turk")}>",
                        func = () =>
                        {
                            if (isInCat("turk"))
                            {
                                client_variable.dish_catagory.Remove("turk");
                            }
                            else
                            {
                                client_variable.dish_catagory.Add("turk");
                            }
                            Catagory();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Return",
                        func = Menu
                        

                    }
                };
                Menu men = new Menu()
                {
                    options = opties,
                    prefix = "Filters"
                };
                men.RunMenu();
            }
            protected void Menu()
            {
                var list = new List<option>();

                list.Add(new option
                {
                    printToConsole = "Filters",
                    func = Catagory
                });
                Action dishitem(Dish d) {
                    void func()
                    {
                        var options = new option[]
                        {
                            new option
                            {
                                printToConsole = "Return",
                                func = Menu
                            }
                        };
                        string temp = "[";
                        foreach(var x in d.Categories)
                        {
                            temp += $"{x} ";
                        }
                        temp += "]";
                        Menu men = new Menu
                        {
                            options = options,
                            prefix = $"Name: {d.Title}\n{d.Description}\nPrice: {d.Price} euro\nCatagories: {temp}"
                        };
                        men.RunMenu();
                    }
                    return func;
                }
                

                foreach (var dish in json_dish.getDishList())
                {
                    if (dish.Spotlighted)
                    {
                        if (dish.Categories.ToArray().Intersect(client_variable.dish_catagory.ToArray()).Any() || client_variable.dish_catagory.Count == 0)
                        list.Add(new option
                        {
                            printToConsole = "-=- " + dish.Title + " -=-",
                            func = dishitem(dish)
                        });
                    }
                }
                foreach (var dish in json_dish.getDishList())
                {

                    if (!dish.Spotlighted)
                    {
                        if (dish.Categories.ToArray().Intersect(client_variable.dish_catagory.ToArray()).Any() || client_variable.dish_catagory.Count == 0)
                            list.Add(new option
                            {
                                printToConsole = dish.Title,
                                func = dishitem(dish)
                            });
                    }
                }
                list.Add(new option
                {
                    printToConsole = "Return",
                    func = new MenuHandler().userMain
                });
                Menu men = new Menu()
                {
                    options = list.ToArray(),
                    prefix = "Menu"
                };
                men.RunMenu();


            }
            
            //General
            public void Main()
            {
                var optie = new option[]
                {
                new option
                {
                    printToConsole = "Menu",
                    func = Menu
                },
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
                    printToConsole = "Change account settings",
                    func = accountSettings
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

            //Reservation Related
            protected Action reservationMenu1(int y)
            {
                void resv()
                {
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
        );
                    }
                    list.Add(new option
                    {
                        printToConsole = "Next Week",
                        func = reservationMenu1(y + 1)
                    });

                    if (y > 0)
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
                        func = this.Main
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
            protected Action reservationMenuDay(DateTime i)
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
                        func = this.reservationMenu1(0)
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
            protected Action makeReservationMenu(DateTime date, table table)
            {
                void MakeReservationMenu()
                {
                    var owncredit = client_variable.user.creditcard;
                    if (client_variable.user.role == "guest")
                    {
                        Console.WriteLine("Enter your Creditcard Number!");
                        var credit = Console.ReadLine();
                        if (Checker.Check(credit))
                        {
                            client_variable.user.creditcard = credit;
                            Console.WriteLine("Please enter your Name!");
                            client_variable.user.username = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                            Console.ReadKey();
                            this.reservationMenu1(0)();
                        }
                    }
                    else
                    {
                        if (client_variable.user.creditcard == "123")
                        {
                            Console.WriteLine("Enter your Creditcard Number!");
                            var credit = Console.ReadLine();
                            if (Checker.Check(credit))
                            {
                                client_variable.user.creditcard = credit;
                                json_customer.updateUserFromClient();
                                owncredit = client_variable.user.creditcard;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                                Console.ReadKey();
                                reservationMenu1(0)();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Do you want to use your account creditcard? YES/NO");
                            string x = Console.ReadLine();

                            if (!(x.ToUpper() == "YES" || x.ToUpper() == "Y"))
                            {

                                Console.WriteLine("Enter your Creditcard Number!");
                                var credit = Console.ReadLine();
                                if (Checker.Check(credit))
                                {
                                    client_variable.user.creditcard = credit;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                                    Console.ReadKey();
                                    reservationMenu1(0)();
                                }
                            }

                        }
                    }

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
                    client_variable.user.creditcard = owncredit;
                    Console.WriteLine("Reservation Complete\n" + "Reservation Code is: " + res.Id);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    new MenuHandler().userMain();
                }
                return MakeReservationMenu;
            }
            protected void userReservationMenu()
            {
                var options = new List<option>();
                foreach (var i in json_reservation.getUserReservations())
                {
                    options.Add(
                        new option
                        {
                            printToConsole = $"{i.Id} - {i.date}",
                            func = reservationMenu(i)
                        }
                        );

                }
                options.Add(new option
                {
                    printToConsole = "Return",
                    func = this.Main
                });

                var menu = new Menu
                {
                    prefix = "Reservations",
                    options = options.ToArray()
                };
                menu.RunMenu();
            }
        }
        protected class GuestMenus : CustomerMenus
        {
            public new void Main()
            {
                client_variable.user = new user()
                {
                    role = "guest"
                };
                var options = new List<option>();
                options.Add(
                new option
                {
                    printToConsole = "Menu",
                    func = Menu
                });
                options.Add(new option
                {
                    printToConsole = "Make Reservation",
                    func = reservationMenu1(0)
                });
                options.Add(new option
                {
                    printToConsole = "Check Reservation",
                    func = guestReservation
                });
                options.Add(new option
                {
                    printToConsole = "Take-Away"
                });
                options.Add(new option
                {
                    printToConsole = "Log-out",
                    func = mainMenu
            });

                Menu men = new Menu
                {
                    options = options.ToArray(),
                    prefix = "Welcome Guest!"
                };
                men.RunMenu();
            }
            private void guestReservation()
            {
                Console.Clear();
                Console.WriteLine(@$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|  
                                           
Search Reservation  ");

                Console.WriteLine("Typ your username of your reservation");
                string username = Console.ReadLine();
                Console.WriteLine("Typ your code of your reservation");
                string code = Console.ReadLine();
                reservation res = json_reservation.GetReservation(code);

                if (json_reservation.doesReservationexist(code))
                {
                    if (res.user.username == username && res.user.role == "guest")
                    {
                        reservationMenu(res)();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or reservation doesn't belong to a guest!\nPress a Key to continue...");
                        Console.ReadKey();
                        this.Main();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Reservation Code!\nPress a Key to continue...");
                    Console.ReadKey();
                    this.Main();
                }
            }
        }

        public MenuHandler()
        {
            this.general = new GeneralMenus();
            this.admin = new AdminMenus();
            this.cashier = new CashierMenus();
            this.customer = new CustomerMenus();
            this.guest = new GuestMenus();
            this.chef = new ChefMenus();
        }
        public void mainMenu()
        {
            this.general.mainMenu();
        }
        public void userMain()
        {
            if (client_variable.user.role == "customer")
            {
                this.customer.Main();
            }
            else if (client_variable.user.role == "guest")
            {
                this.guest.Main();
            }
            else if (client_variable.user.role == "cashier")
            {
                this.cashier.Main();
            }
            else if (client_variable.user.role == "admin")
            {
                this.admin.Main();
            }
            else if (client_variable.user.role == "chef")
            {
                this.chef.Main();
            }
        }


    }
}
