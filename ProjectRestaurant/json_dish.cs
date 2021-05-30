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
                    Price = (float)5.50,
                    Description = "Deze soep is gemaakt van linzen.",
                    Spotlighted = false,
                    Categories = new List<string>(),
                    Stock = 1
                });

                string jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(@"dish.json", jsonString);
            }
        }

        public static Action update(Dish dish, int num)
        {
            void f()
            {
                if (0 < num && num < 7)
                {
                    var data = getDishList();
                    foreach (var i in data)
                    {
                        if (i.UID == dish.UID)
                        {
                            if (num == 1)
                            {
                                Console.WriteLine("Type a name of the Dish");
                                var key = Console.ReadLine();
                                if (key.GetType() == i.Title.GetType())
                                {
                                    i.Title = key;
                                    Console.WriteLine("Succesfully changed the name! Press enter to continue...");
                                    Console.ReadLine();
                                }
                            }
                            else if (num == 2)
                            {
                                Console.WriteLine("Type a price of the Dish");
                                double key;
                                try
                                {
                                    key = Convert.ToDouble(Console.ReadLine());
                                    i.Price = (float)key;
                                }
                                catch
                                {
                                    Console.WriteLine("Error: That was not a number! Press enter to continue...");
                                    Console.ReadLine();
                                    update(dish, 2);
                                }   
                            }
                            else if (num == 3)
                            {
                                Console.WriteLine("Type the Description of the Dish");
                                var key = Console.ReadLine();
                                if (key.GetType() == i.Description.GetType())
                                    i.Description = key;
                                    Console.WriteLine("Succesfully changed the description! Press enter to continue...");
                                    Console.ReadLine();
                            }
                            else if (num == 4)
                            {
                                Func<bool, bool> f = x => !x;
                                i.Spotlighted = f(i.Spotlighted);
                                Console.WriteLine($"Succesfully changed the Spotlighten to {i.Spotlighted}! Press enter to continue...");
                                Console.ReadLine();
                            }
                            else if (num == 5)
                            {
                                int count = 1;
                                foreach (var cat in i.Categories)
                                {
                                    Console.WriteLine($"{count++} : {cat}");
                                }

                                Console.WriteLine($"Do you want to add or delete an category? Type 'add' or 'delete'");
                                var input = Console.ReadLine();
                                while (input != "add" && input != "delete")
                                {
                                    Console.WriteLine($"Wrong keypress! Type 'add' or 'delete'");
                                    Console.WriteLine(input);
                                    input = Console.ReadLine();
                                }
                                if (input == "add")
                                {
                                    Console.WriteLine($"Type the category to add");
                                    var name = Console.ReadLine();
                                    i.AddCat(name);
                                    Console.WriteLine("Succesfully added a category! Press enter to continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Type the category to delete");
                                    var name = Console.ReadLine();
                                    if (i.Categories.Any(e => e.EndsWith(name)))
                                    {
                                        i.RemoveCat(name);
                                        Console.WriteLine("Succesfully changed the description! Press enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Category does not exist. Press enter to continue...");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            else if (num == 6)
                            {
                                int key;
                                try
                                {
                                    Console.WriteLine("Type the amount of the Stock.");
                                    key = Convert.ToInt32(Console.ReadLine());
                                    i.UpdateStock(key);
                                    Console.WriteLine("Succesfully changed the Stock. Press enter to continue...");
                                    Console.ReadLine();
                                }
                                catch
                                {
                                    Console.WriteLine("Error: That was not a number! Press enter to try again...");
                                    Console.ReadLine();
                                    update(dish, 6);
                                }
                            }
                        }
                    }
                    var jsonString = JsonSerializer.Serialize(data);
                    File.WriteAllText(@"dish.json", jsonString);
                }
            }
            return f;
        }



        public static Action addDish(Dish dish)
        {
            void tes()
            {
                var data = getDishList();
                dish.UID = data.Count + 1;
                data.Add(dish);
                var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<Dish>>(data);
                File.WriteAllText(@"dish.json", jsonString);
            }
            return tes;
        }
        public static Action removeDish(int id)
        {
            void tes()
            {

                var data = getDishList();
                data.RemoveAll(i => i.UID == id);
                var jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(@"dish.json", jsonString);
            }
            return tes;
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
                Console.WriteLine($"Price: {x.Price}"); 
                Console.WriteLine($"Description: {x.Description}");
                Console.WriteLine($"This dish is currently{(x.Spotlighted ? "" : " not")} Spotlighted");
                Console.WriteLine($"Categories: {x.ShowAllCat()}");
                Console.WriteLine($"Stock: {x.Stock}");
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
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
        public static void SetStartDate(Dish dish, DateTime date)
        {
            var data = getDishList();
            foreach (var i in data)
            {
                if (i.UID == dish.UID)
                {
                    i.startDate = date;
                }
            }
            var jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(@"dish.json", jsonString);
        }
        public static void SetEndDate(Dish dish, DateTime date)
        {
            var data = getDishList();
            foreach (var i in data)
            {
                if (i.UID == dish.UID)
                {
                    i.startDate = date;
                }
            }
            var jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(@"dish.json", jsonString);
        }
    }
}
