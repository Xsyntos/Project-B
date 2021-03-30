using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectRestaurant
{
    [System.Serializable]
    public class takeaway
    {

        public int Id { get; set; }
        // string foodname will probably change into a list later on the project.
        public string foodname { get; set; }
        public string user { get; set; }
        public string time { get; set; }
        public string creditcardnumber { get; set; }

    }
    class json_takeaway
    {
        public static void takeawayInit()
        {
            if (!File.Exists(@"takeaway.json"))
            {
                List<takeaway> data = new List<takeaway>();
                for (int i = 1; i <= 8; i++)
                {
                    data.Add(new takeaway()
                    {
                        Id = i,
                        foodname = $"Fake foodname number: {i}",
                        user = $"Fake name number: {i}",
                        time = $"{i}{i}:{i}{i}",
                        creditcardnumber = Hash.Encrypt("01234567891234"),

                    });
                }
                string jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<takeaway>>(data);
                File.WriteAllText(@"takeaway.json", jsonString);
            }
        }
        public static void addtakeaway(string foodname, string user, string time, string creditcardnumber)
        {
            var data = gettakeawayList();
            data.Add(new takeaway()
            {
                Id = data[data.Count - 1].Id + 1,
                foodname = foodname,
                user = user,
                time = time,
                creditcardnumber = Hash.Encrypt(creditcardnumber)

            }); ;
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<takeaway>>(data);
            File.WriteAllText(@"takeaway.json", jsonString);
        }
        public static void removetakeaway(int id)
        {
            var data = gettakeawayList();
            data.RemoveAll(i => i.Id == id);
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<takeaway>>(data);
            File.WriteAllText(@"takeaway.json", jsonString);
        }

        public static List<takeaway> gettakeawayList()
        {
            string jsonString = File.ReadAllText(@"takeaway.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<takeaway>>(jsonString);
            return data;
        }
        public static void displaytakeaway()
        {
            var data = gettakeawayList();
            foreach (var x in data)
            {
                Console.WriteLine($"ID: {x.Id}");
                Console.WriteLine($"foodname: {x.foodname}"); // list comprehension for food for later when it will get changed.
                Console.WriteLine($"User: {x.user}");
                Console.WriteLine($"Time: {x.time}");
                Console.WriteLine($"Creditcardnumber: {Hash.Encrypt(x.creditcardnumber)}");
                Console.WriteLine("-------------------------------");
            }
        }
        public static takeaway gettakeawayFromId(int id)
        {
            var data = gettakeawayList();
            foreach (var i in data)
            {
                if (i.Id == id)
                {
                    return i;
                }
            }
            return new takeaway();
        }
    }
}
