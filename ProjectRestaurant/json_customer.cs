using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ProjectRestaurant
{
    [System.Serializable]
    public class user
    {

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string creditcard { get; set; }
        public string role { get; set; }
    }

    class json_customer
    {
        public static void customerinit()
        {
            if (!File.Exists(@"users.json"))
            {
                List<user> data = new List<user>();
                data.Add(new user()
                {
                    Id = 1,
                    username = "Admin",
                    password = "admin",
                    creditcard = "-admin-",
                    role = "admin"
                });

                data.Add(new user()
                {
                    Id = 2,
                    username = "Chef",
                    password = "chef",
                    creditcard = "-Chef-",
                    role = "chef"
                });
                string jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
                File.WriteAllText(@"users.json", jsonString);
            }
        }

        public static void newUser(string us, string pass, string credit, string role = "customer")
        {
            var data = getUserlist();
            data.Add(new user()
            {
                Id = data[data.Count - 1].Id + 1,
                username = us,
                password = pass,
                creditcard = credit,
                role = role
            }); ;
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
            File.WriteAllText(@"users.json", jsonString);
        }
       
        public static void removeWithName(string name)
        {
            var data = getUserlist();
            int index = -1;
            var i = 0;
            while (i < data.Count)
            {
                if (data[i].username == name)
                {
                    index = i;
                    i = data.Count;
                    data.RemoveAt(index);
                }
                i++;
            }
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
            File.WriteAllText(@"users.json", jsonString);
        }

        public static void removeWithID(int i)
        {
            var data = getUserlist();
            data.RemoveAll(u => u.Id == i);
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
            File.WriteAllText(@"users.json", jsonString);
        }

        public static List<user> getUserlist()
        {
            string jsonString = File.ReadAllText(@"users.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<user>>(jsonString);
            return data;
        }

        public static void displayUser()
        {
            var data = getUserlist();
            foreach(var x in data)
            {
                Console.WriteLine($"Username: {x.username}") ;
                Console.WriteLine($"ID: {x.Id}");
                Console.WriteLine("-------------------------------");
            }
        }

    }
}
