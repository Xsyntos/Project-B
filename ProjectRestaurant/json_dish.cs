using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace ProjectRestaurant
{
    class json_dish
    {
        public static void dishInit()
        {
            if (!File.Exists(@"dish.json"))
            {
                List<Dish> data = new List<Dish>();
                data.Add(new Dish()
                {
                    UID = 1,
                    Title = "Linzen Soep",
                    Price = 5.50,
                    Description = "Deze soep is gemaakt van linzen.",
                    Spotlighted = false,
                    Categories = new List<string>()
                });

                string jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(@"dish.json", jsonString);
            }
        }

        public static Action update(Dish dish)
        {
            void tes()
            {
                var option = new List<option>();
                option.Add(new option()
                {
                    printToConsole = "Title",
                    func = action(1)
                });
                option.Add(new option()
                {
                    printToConsole = "Price",
                    func = action(2)
                });
                option.Add(new option()
                {
                    printToConsole = "Description",
                    func = action(3)
                });
                option.Add(new option()
                {
                    printToConsole = "Spotlighted",
                    func = action(4)
                });
                option.Add(new option()
                {
                    printToConsole = "Categories",
                    func = action(5)
                });

                Action action(int num)
                {
                    void f()
                    {
                        if (0 < num && num < 6)
                        {
                            var data = getDishList();
                            // Console.WriteLine("What do you want to change?");
                            foreach (var i in data)
                            {
                                if (i.UID == dish.UID)
                                {
                                    if (num == 1)
                                    {
                                        Console.WriteLine("Type a name of the Dish");
                                        var key = Console.ReadLine();
                                        if (key.GetType() == i.Title.GetType())
                                            i.Title = key;
                                        else
                                            update(dish);
                                    }
                                    else if (num == 2)
                                    {
                                        var key = Console.ReadLine();
                                        if (key.GetType() == i.Price.GetType())
                                            i.Title = key;
                                        else
                                            update(dish);
                                    }
                                    else if (num == 3)
                                    {
                                        var key = Console.ReadLine();
                                        if (key.GetType() == i.Description.GetType())
                                            i.Title = key;
                                        else
                                            update(dish);
                                    }
                                    else if (num == 4)
                                    {
                                        Func<bool, bool> f = x => !x;
                                        i.Spotlighted = f(i.Spotlighted);
                                    }
                                    else if (num == 5)
                                    {
                                        foreach (var cat in i.Categories)
                                        {
                                            int count = 1;
                                            Console.WriteLine($"{count} : {cat}");
                                        }

                                        Console.WriteLine($"Do you want to add or delete an category? Type 'add' or 'delete'");
                                        var input = Console.ReadLine();
                                        while (input != "add" || input != "delete")
                                        {
                                            Console.WriteLine($"Wrong keypress! Type 'add' or 'delete'");
                                            input = Console.ReadLine();
                                        }
                                        if (input == "add")
                                        {
                                            Console.WriteLine($"Type the category to add");
                                            var name = Console.ReadLine();
                                            i.Categories.Append(name);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Type the category to delete");
                                            var name = Console.ReadLine();
                                            if (i.Categories.Any(e => e.EndsWith(name)))
                                                i.Categories.Remove(name);

                                            else
                                                Console.WriteLine("Category does not exist.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return f;
                }
                Menu menu = new Menu
                {
                    options = option.ToArray(),
                    prefix = "Select an option"
                };
                menu.RunMenu();
            }
            return tes;
        }
        public static void addDish(Dish dish)
        {
            var data = getDishList();
            dish.UID = data.Count + 1;
            data.Add(dish);
            var jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(@"dish.json", jsonString);
        }
        public static void removeDish(int id)
        {
            var data = getDishList();
            data.RemoveAll(i => i.UID == id);
            var jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(@"dish.json", jsonString);
        }

        public static List<Dish> getDishList()
        {
            string jsonString = File.ReadAllText(@"dish.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<Dish>>(jsonString);
            return data;
        }
        public static void displayAllDish()
        {
            var data = getDishList();
            foreach (var x in data)
            {
                Console.WriteLine($"Title: {x.Title}");
                Console.WriteLine($"Price: {x.Price}"); // list comprehension for food for later when it will get changed.
                Console.WriteLine($"Description: {x.Description}");
                Console.WriteLine($"This dish is currently {x.Spotlighted}");
                Console.WriteLine($"Categories: {x.ShowAllCat()}");
                Console.WriteLine("-------------------------------");
            }
        }
        public static Dish getDish(int id)
        {
            var data = getDishList();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].UID == id)
                {
                    return data[i];
                }

            }
            return new Dish();
        }
    }
}
