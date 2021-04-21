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
        public static void update(Dish dish)
        {
            var data = getDishList();
            foreach(var i in data)
            {
                if (i.UID == dish.UID)
                {
                    i.Title = dish.Title;
                    i.Price = dish.Price;
                    i.Description = dish.Description;
                    i.Spotlighted = dish.Spotlighted;
                    i.Categories = dish.Categories;
                }
            }
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
