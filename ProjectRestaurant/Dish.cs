using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    public class Dish
    {
        public int UID { set; get; }
        public string Title { set; get; }
        public float Price { set; get; }
        public string Description { set; get; }
        public bool Spotlighted { set ; get; }
        public List<string> Categories{ set; get; }
        public int Stock { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }

        public string ShowAllCat()
        {
            int num = 1;
            string result = "";
            foreach (string cat in Categories)
            {
                result += $"{num++}: {cat}. ";
            }
            return result;
        }
        public void AddCat(string name)
        {
            Categories.Add(name);
        }

        public void RemoveCat(string name)
        {   
            foreach(var category in Categories.ToArray())
            {
                if (name == category)
                    Categories.Remove(name);
                Console.WriteLine($"{name} has been succesfully removed!");
            }
        }
        
        public void UpdateStock(int input)
        {
            Stock = input;
        }
    }
}
