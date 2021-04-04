using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ProjectRestaurant
{
    [System.Serializable]
    public class reservation
    {

        public string Id { get; set; }
        public DateTime date { get; set; }
        public user user { get; set; }
        public table table { get; set; }
    }



    class json_reservation
    {
        public static void reservationInit()
        {
            if (!File.Exists(@"reservation.json"))
            {
                List<reservation> data = new List<reservation>();
                string jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<reservation>>(data);
                File.WriteAllText(@"reservation.json", jsonString);
            }
        }

        public static void clearOldreservation()
        {
            var data = getReservationlist();
            data.RemoveAll(i => i.date < DateTime.Now);

            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<reservation>>(data);
            File.WriteAllText(@"reservation.json", jsonString);
        }

        public static void makeReservation(DateTime Date, user User, table Table)
        {
            var data = getReservationlist();
            data.Add(new reservation()
            {
                Id = resKey(),
                date = Date,
                user = User,
                table = Table
            });
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<reservation>>(data);
            File.WriteAllText(@"reservation.json", jsonString);
        }
        
        public static void removeReservation(string id)
        {
            var data = getReservationlist();
            data.RemoveAll(item => item.Id == id);
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<reservation>>(data);
            File.WriteAllText(@"reservation.json", jsonString);
        }

        private static Random random = new Random();
        public static string resKey(int length = 12)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string x = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            string jsonString = File.ReadAllText(@"reservation.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<reservation>>(jsonString);
            foreach (var i in data)
            {
                if (x == i.Id)
                {
                    return resKey();
                }
            }
            return x;
        }
        public static List<reservation> getReservationlist()
        {
            string jsonString = File.ReadAllText(@"reservation.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<reservation>>(jsonString);
            return data;
        }

        public static void displayReservation()
        {
            var data = getReservationlist();
            foreach (var x in data)
            {
                Console.WriteLine($"ID: {x.Id}");
                Console.WriteLine($"Date: {x.date}");
                Console.WriteLine($"User: {x.user.Id}");
                Console.WriteLine($"    Username: {x.user.username}");
                Console.WriteLine($"Table: {x.table.Id}");
                Console.WriteLine($"    Capacity: {x.table.capacity}");
                Console.WriteLine("     VIP: {x.table.vip}");
                Console.WriteLine("-------------------------------");
            }
        }

        public static reservation[] reservationsofdate(DateTime date)
        {
            clearOldreservation();
            var data = getReservationlist();
            var list = new List<reservation>();
            foreach(var i in data)
            {
                if(i.date == date)
                {
                    list.Add(i);
                }
            }
            return list.ToArray();
        }
        public static List<reservation> getUserReservations()
        {
            clearOldreservation();
            var data = getReservationlist();
            data.RemoveAll(i => (i.user.Id != client_variable.user.Id) || (i.user.username != client_variable.user.username));
            return data;
        }
    }
}
