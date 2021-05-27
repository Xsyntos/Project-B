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
                    password = Hash.Encrypt("admin"),
                    creditcard = "-admin-",
                    role = "admin"
                });

                data.Add(new user()
                {
                    Id = 2,
                    username = "Chef",
                    password = Hash.Encrypt("chef"),
                    creditcard = "-Chef-",
                    role = "chef"
                });
                data.Add(new user()
                {
                    Id = 3,
                    username = "Cashier",
                    password = Hash.Encrypt("cashier"),
                    creditcard = "-Cashier-",
                    role = "cashier"
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

        public static Action delete(user user)
        {
            void tes()
            {
                var data = getUserlist();
                data.RemoveAll(u => u.Id == user.Id);
                var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
                File.WriteAllText(@"users.json", jsonString);
            }
            return tes;
        }

        public static List<user> getUserlist()
        {
            string jsonString = File.ReadAllText(@"users.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<user>>(jsonString);
            return data;
        }

        protected static user getUser(int id)
        {
            var data = getUserlist();
            for(int i = 0; i < data.Count; i++)
            {
                if(data[i].Id == id)
                {
                    return data[i];
                }
                
            }
            return new user();
        }
        public static void displayAllUsers()
        {
            var data = getUserlist();
            foreach (var x in data)
            {
                Console.WriteLine($"User ID: {x.Id}");
                Console.WriteLine($"User Name: {x.username}");
                Console.WriteLine($"User Password: {x.password}");
                Console.WriteLine($"User Role: {x.role}");
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }
        public static Action Update(user user, string role)
        {
            void f()
            {
                var data = getUserlist();
                foreach (var i in data)
                {
                    if (i.Id == user.Id)
                    {
                        i.role = role;
                        Console.WriteLine("\nRole has been changed. Press enter to continue...");
                        Console.ReadLine();
                    }
                }
                var jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(@"users.json", jsonString);
            }
            return f;
        }
        public static void updateUserFromClient()
        {
            var data = getUserlist();
            data.RemoveAll(u => u.Id == client_variable.user.Id);
            data.Add(client_variable.user);
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<user>>(data);
            File.WriteAllText(@"users.json", jsonString);
        }
    }
}
