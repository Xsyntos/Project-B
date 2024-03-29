﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Reflection;

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
            public override void Main()
            {
               var x = new option[]
               {
                   new option
                   {
                       printToConsole = "Check all reservations",
                   },
                   new option
                   {
                       printToConsole = "View all Dishes",
                       func = displayAllDishes
                   },
                   new option
                   {
                       printToConsole = "Update Dishes",
                       func = getAllDishes
                   },
                   new option
                   {
                       printToConsole = "Edit Users",
                       func = editUserMenu
                   },
                   new option
                   {
                       printToConsole = "Edit tables",
                       func = capacity
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
            private void capacity()
            {
                var availabletables = json_table.getTableList();
                var option = new List<option>();
                foreach (var i in availabletables)
                {
                    if (i.vip)
                    {
                        option.Add(new option
                        {
                            printToConsole = $"{i.Id}. {i.capacity} persons VIP",
                            func = editTable(i)
                        }
                        );
                    }
                    else
                    {
                        option.Add(new option
                        {
                            printToConsole = $"{i.Id}. {i.capacity} persons",
                            func = editTable(i)
                        }
                        );
                    }


                }
                option.Add(new option
                {
                    printToConsole = "Add Table",
                    func = createTable
                });
                option.Add(new option
                {
                    printToConsole = "Return",
                    func = new MenuHandler().userMain
                });
                Menu menu = new Menu
                {
                    options = option.ToArray(),
                    prefix = "Select a Table"

                };

                menu.RunMenu();
            }
            private Action editTable(table t)
            {
                void f()
                {
                    var optie = new option[] {
                        new option()
                        {
                            printToConsole = "Change VIP",
                            func = () =>
                            {
                                json_table.changeVIP(t.Id);
                                editTable(json_table.getTableFromId(t.Id))();
                            }
                        },
                        new option()
                        {
                            printToConsole = "Change Capacity",
                            func = () =>
                            {
                                int x = 0;
                                Console.WriteLine("Enter the new Capacity!");
                                string input = Console.ReadLine();
                                try
                                {
                                    x = Int32.Parse(input);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input! Press Enter to Continue...");
                                    Console.ReadKey();
                                    editTable(json_table.getTableFromId(t.Id))();
                                }
                                if(x <= 0)
                                {
                                    Console.WriteLine("Invalid input! Press Enter to Continue...");
                                    Console.ReadKey();
                                    editTable(json_table.getTableFromId(t.Id))();
                                }
                                json_table.changeCap(t.Id, x);
                                editTable(json_table.getTableFromId(t.Id))();
                            }
                        },
                        new option()
                        {
                            printToConsole = "Return",
                            func = capacity
                        }
                    };

                    var men = new Menu()
                    {
                        prefix = $"Id: {t.Id}\nCapacity: {t.capacity}\nVIP: {t.vip}",
                        options = optie
                    };
                    men.RunMenu();

                }
                return f;
            }

            private void createTable()
            {
                Console.Clear();
                string prompt = @$"

                                           
 _____         _                       _   
| __  |___ ___| |_ ___ _ _ ___ ___ ___| |_ 
|    -| -_|_ -|  _| .'| | |  _| .'|   |  _|
|__|__|___|___|_| |__,|___|_| |__,|_|_|_|";
                prompt += "\n+-------------------------------------------------------------+\n";
                prompt += "Create Table";
                prompt += "\n+-------------------------------------------------------------+";
                Console.WriteLine(prompt);
                Console.WriteLine("For how many guests is the table? (Type q or quit to cancel the table creation!)");
                string input = Console.ReadLine();
                if (input.ToUpper() == "Q" || input.ToUpper() == "QUIT")
                {
                    Console.WriteLine("Table Creation canceled! Press Enter to continue...");
                    Console.ReadKey();
                    this.capacity();
                }
                else
                {
                    int x = 0;
                    try
                    {
                        x = Int32.Parse(input);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input! Press Enter to continue...");
                        Console.ReadKey();
                        this.capacity();
                    }
                    if (x <= 0)
                    {
                        Console.WriteLine("Invalid input! Press Enter to continue...");
                        Console.ReadKey();
                        this.capacity();
                    }
                    Console.WriteLine("Is the table VIP type 'Yes' or 'No'? (Type an invalid input to cancel the table creation!)");
                    string input2 = Console.ReadLine();
                    if (input2.ToUpper() == "YES" || input2.ToUpper() == "Y")
                    {
                        json_table.addTable(x, true);
                        Console.WriteLine("You have added succesfully a table! Press Enter to continue...");
                        Console.ReadKey();
                        this.capacity();
                    }
                    else if (input2.ToUpper() == "NO" || input2.ToUpper() == "N")
                    {
                        json_table.addTable(x, false);
                        Console.WriteLine("You have added succesfully a table! Press Enter to continue...");
                        Console.ReadKey();
                        this.capacity();
                    }
                    else
                    {
                        Console.WriteLine("Table Creation canceled! Press Enter to continue...");
                        Console.ReadKey();
                        this.capacity();
                    }
                }


            }


            private void editUserMenu() 
            {
               var x = new option[]
               {
                    new option
                    {
                        printToConsole = "View all Users",
                        func = displayAllUsers
                    },
                    new option
                    {
                        printToConsole = "Update a User",
                        func = getUsersUpdate
                    },
                    new option
                    {
                        printToConsole = "Delete a User",
                        func = getUsersDelete
                    },
                    new option
                    {
                        printToConsole = "Return",
                        func = Main
                    }
               };
               var menu = new Menu
               {
                    prefix = "Welcome Boss",
                    options = x
               };
               menu.RunMenu();
            }
            private void displayAllUsers()
            {
                json_customer.displayAllUsers();
                editUserMenu();
            }
            private void getUsersUpdate()
            {
                var x = new option[json_customer.getUserlist().Count];
                for (int i = 0, j = 0; i < json_customer.getUserlist().Count; i++)
                {
                    if (json_customer.getUserlist()[i].role != "admin")
                    {
                        x[j++] = new option
                        {
                            printToConsole = $"{json_customer.getUserlist()[i].username}",
                            func = roleOptions(json_customer.getUserlist()[i])
                        };
                    }
                }
                x[x.Length - 1] = new option
                {
                    printToConsole = "Return",
                    func = Main
                };
                var menu = new Menu
                {
                    prefix = $"Welcome {client_variable.user.role}",
                    options = x
                };
                menu.RunMenu();

            }
            private void getUsersDelete()
            {
                var x = new option[json_customer.getUserlist().Count];
                for (int i = 0, j = 0; i < json_customer.getUserlist().Count; i++)
                {
                    if (json_customer.getUserlist()[i].role != "admin")
                    {
                        x[j++] = new option
                        {
                            printToConsole = $"{json_customer.getUserlist()[i].username}",
                            func = Delete(json_customer.getUserlist()[i])
                        };
                    }
                }
                x[x.Length - 1] = new option
                {
                    printToConsole = "Return",
                    func = Main
                };
                var menu = new Menu
                {
                    prefix = $"Welcome {client_variable.user.role}",
                    options = x
                };
                menu.RunMenu();

            }
            private Action roleOptions(user user)
            {
                void tes()
                {
                    var x = new option[]
                    {
                        new option
                        {
                            printToConsole = "Customer",
                            func = UpdateRole(user, "customer")
                        },
                        new option
                        {
                            printToConsole = "Cashier",
                            func = UpdateRole(user, "cashier")
                        },
                        new option
                        {
                            printToConsole = "Chef",
                            func = UpdateRole(user, "chef")
                        },
                        new option
                        {
                            printToConsole = "Return",
                            func = editUserMenu
                        }
                    };
                    var menu = new Menu
                    {
                        prefix = "Select a role",
                        options = x
                    };
                    menu.RunMenu();
                }
                return tes;
            }
            private Action UpdateRole(user user, string role)
            {
                void tes()
                {
                    try
                    {
                        json_customer.Update(user, role)();
                    }
                    catch
                    {
                        Console.WriteLine("Error!!!!!");
                        Console.ReadLine();
                    }
                    Main();
                }
                return tes;
            }
            private Action Delete(user user)
            {
                void tes()
                {  
                    if(user.role != "admin")
                        json_customer.delete(user)();
                    Main();
                }
                return tes;
            }
        }
        protected class ChefMenus : GeneralMenus
        {
            public virtual void Main()
            {
                var x = new option[]
                {
                   new option
                   {
                       printToConsole = "View all Dishes",
                       func = displayAllDishes
                   },
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

            protected void displayAllDishes()
            {
                json_dish.displayAllDish();
                Main();
            }

            protected void getAllDishes()
            {
                var x = new option[json_dish.getDishList().Count + 1];
                for (int i = 0; i < json_dish.getDishList().Count; i++)
                {
                    x[i] = new option
                    {
                        printToConsole = $"{json_dish.getDishList()[i].Title}",
                        func = listSettingsDish(json_dish.getDishList()[i])
                    };
                }
                x[x.Length-1] = new option
                {
                    printToConsole = "Return",
                    func = Main
                };
                var menu = new Menu
                {
                    prefix = $"Welcome {client_variable.user.role}",
                    options = x
                };
                menu.RunMenu();

            }

            private void addDishes()
            {
                Console.WriteLine("What is the name of the dish:");
                string name = Console.ReadLine();
                Console.WriteLine("What is the price of the dish:");
                try { 
                    Double price = Convert.ToDouble(Console.ReadLine());
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
                    new MenuHandler().userMain();
                }
                catch { 
                    Console.WriteLine("Invalid Input! adding dish canceld\n Press Enter to continue...");
                    Console.ReadKey();
                    new MenuHandler().userMain();
                }
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
                    if (client_variable.user.role == "admin")
                    {
                        option.Add(new option()
                        {
                            printToConsole = "Price",
                            func = updateDish(dish, 2)
                        });
                    }
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
                    if (client_variable.user.role == "admin")
                    {
                        option.Add(new option()
                        {
                            printToConsole = "Change Date",
                            func = changeDateSettings(dish)
                        });
                    }
                    option.Add(new option()
                    {
                        printToConsole = "Return",
                        func = getAllDishes
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

            protected Action changeDateSettings(Dish dish)
            {
                void func() 
                { 
                    var option = new List<option>();
                    option.Add(new option()
                    {
                        printToConsole = "Set Start Date",
                        func = setStartDate(dish)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Set End Date",
                        func = setEndDate(dish)
                    });
                    option.Add(new option()
                    {
                        printToConsole = "Return",
                        func = listSettingsDish(dish)
                    });
                    Menu menu = new Menu
                    {
                        options = option.ToArray(),
                        prefix = "Select an option"
                    };
                    menu.RunMenu();
                }
                return func;
            }
            // TODO
            // setDate() moet veranderen van self-input naar een date option menu.
            private DateTime setDate()
            {
                Console.WriteLine("What should be the Date? To cancel, press 'q'. Format is DD/MM/YYYY");
                string iDate = Console.ReadLine();
                DateTime oDate = Convert.ToDateTime(iDate);
                return oDate;
            }
            protected Action setStartDate(Dish dish)
            {
                void func()
                {
                    try
                    {
                        DateTime date = setDate();
                        json_dish.SetStartDate(dish, date);
                        Console.WriteLine("Start Date has been set! Press Enter to continue...");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadKey();
                    }
                    listSettingsDish(json_dish.getDish(dish.UID))();
                }
                return func;
            }
            protected Action setEndDate(Dish dish)
            {
                void func()
                {
                    try
                    {
                        DateTime date = setDate();
                        json_dish.SetEndDate(dish, date);
                        Console.WriteLine("End Date has been set! Press Enter to continue...");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadKey();
                    }
                    listSettingsDish(json_dish.getDish(dish.UID))();
                }
                return func;
            }

            protected Action updateDish(Dish dish, int num)
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
                var x = new option[json_dish.getDishList().Count + 1];
                for (int i = 0; i < json_dish.getDishList().Count; i++)
                {
                    x[i] = new option
                    {
                        printToConsole = $"{json_dish.getDishList()[i].Title}",
                        func = deleteDish(json_dish.getDishList()[i].UID)
                    };
                }
                x[x.Length - 1] = new option
                {
                    printToConsole = "Return",
                    func = Main
                };
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
                    func = takeaway()

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
            //take-away
            protected Action takeaway(List<Dish> food = null)
            {
                if (food is null)
                    food = new List<Dish>();
                void func()
                {
                    void cat()
                    {
                        bool isInCat(string s)
                        {
                            return client_variable.dish_catagory.ToArray().Intersect(new string[] { s }).Any();
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
                            cat();
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
                            cat();
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
                            cat();
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
                            cat();
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
                            cat();
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
                            cat();
                        }

                    },
                    new option
                    {
                        printToConsole = $"Return",
                        func = foods


                    }
                        };
                        Menu men = new Menu()
                        {
                            options = opties,
                            prefix = "Filters"
                        };
                        men.RunMenu();
                    }
                    void foods()
                    {

                        var list = new List<option>();

                        list.Add(new option
                        {
                            printToConsole = "Filters",
                            func = cat
                        });
                        Action dishitem(Dish d)
                        {
                            void func()
                            {
                                food.Add(d);
                                Console.WriteLine($"{d.Title} added to takeaway!\nPress Enter to Continue...");
                                Console.ReadKey();
                                foods();

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
                            printToConsole = "Overview",
                            func = Overview(food)
                        });
                        list.Add(new option
                        {
                            printToConsole = "Finish your Take-Away!",
                            func = takeaway2(food)
                        });
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
                    foods();
                }
                return func;
            }
           
            protected Action Overview(List<Dish> food)
            {   
                void func2()
                {
                    var data = food;
                    var x = new option[food.Count + 1];
                    for (int i = 0; i < food.Count; i++)
                    {
                        x[i] = new option
                        {
                            printToConsole = $"{food[i].Title}",
                            func = DeleteItemBasket(food[i], data)
                        };
                    }
                    x[x.Length - 1] = new option
                    {
                        printToConsole = "Return",
                        func = takeaway(food)
                    };
                    var menu = new Menu
                    {
                        prefix = $"Welcome {client_variable.user.role}",
                        options = x
                    };
                    menu.RunMenu();
                }
                return func2;
            }
          
            private Action DeleteItemBasket(Dish dish, List<Dish> data)
            {
                void f()
                {
                    data.Remove(dish);
                    Overview(data)();
                }
                return f;
            }

            protected Action takeaway2(List<Dish> dishes)
            {
                void f()
                {
                    var x = 22 - DateTime.Now.Hour;
                    var optie = new List<option>();

                    for(int i = 0; i < x; i++)
                    {
                        optie.Add(new option()
                        {
                            printToConsole = $"{DateTime.Now.Hour + i+1}:00",
                            func = takeaway3(dishes, new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, (DateTime.Now.Hour + i + 1),0,0))
                        });
                    }
                    optie.Add(new option() {
                        printToConsole = "Return",
                        func = new MenuHandler().userMain
                    });

                    var men = new Menu()
                    {
                        options = optie.ToArray(),
                        prefix = "Select a Time to pick up your take-away"
                    };
                    men.RunMenu();

                }
                return f;
            }
            protected Action takeaway3(List<Dish> dishes, DateTime date)
            {
                void f() {
                    if (client_variable.user.role == "guest")
                    {
                        Console.WriteLine("Enter your Creditcard Number! Or type 'cancel' to cancel the creation of a take-away");
                        var credit = Console.ReadLine();
                        if (credit.ToUpper() == "CANCEL")
                        {
                            new MenuHandler().userMain();
                        }
                        else if (Checker.Check(credit))
                        {
                            client_variable.user.creditcard = credit;
                            Console.WriteLine("Please enter your Name!");
                            client_variable.user.username = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                            Console.ReadKey();
                            this.takeaway3(dishes, date)();
                        }
                    }
                    else
                    {
                        if (client_variable.user.creditcard == "123")
                        {
                            Console.WriteLine("Enter your Creditcard Number! Or type 'cancel' to cancel the creation of a take-away");
                            var credit = Console.ReadLine();
                            if (credit.ToUpper() == "CANCEL")
                            {
                                new MenuHandler().userMain();
                            }
                            else if (Checker.Check(credit))
                            {
                                client_variable.user.creditcard = credit;
                                json_customer.updateUserFromClient();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                                Console.ReadKey();
                                this.takeaway3(dishes, date)();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Do you want to use your account creditcard? YES/NO");
                            string x = Console.ReadLine();

                            if (!(x.ToUpper() == "YES" || x.ToUpper() == "Y"))
                            {

                                Console.WriteLine("Enter your Creditcard Number! Or type 'cancel' to cancel the creation of a take-away");
                                var credit = Console.ReadLine();
                                if (credit.ToUpper() == "CANCEL")
                                {
                                    new MenuHandler().userMain();
                                }
                                else if (Checker.Check(credit))
                                {
                                    client_variable.user.creditcard = credit;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Creditcard number!\nPress a Key to continue...");
                                    Console.ReadKey();
                                    this.takeaway3(dishes, date)();
                                }
                            }

                        }
                    }
                    var ids = new List<int>();
                    double totalprice = 0.0;
                    foreach(var x in dishes )
                    {
                        ids.Add(x.UID);
                        totalprice += x.Price;
                    }
                    
                    json_takeaway.addtakeaway(ids.ToArray(), client_variable.user, date);
                    Console.WriteLine("Ordered Dishes:");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish.Title);
                    }
                    Console.WriteLine($"Succesfully created a take-away with a total price of {totalprice} euro. Press Enter to Continue...");
                    Console.ReadKey();
                    new MenuHandler().userMain();
                }
                return f;
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
                    printToConsole = "Take-Away",
                    func = takeaway()
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
