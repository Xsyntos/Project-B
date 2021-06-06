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
        public int[] foodname { get; set; }
        public user user { get; set; }
        public DateTime time { get; set; }

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
                        foodname = new int[3],
                        user =  new user(),
                        time = DateTime.Now

                    });
                }
                string jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<takeaway>>(data);
                File.WriteAllText(@"takeaway.json", jsonString);
            }
        }
        public static void addtakeaway(int[] foodname, user user, DateTime time)
        {
            var data = gettakeawayList();
            data.Add(new takeaway()
            {
                Id = data[data.Count - 1].Id + 1,
                foodname = foodname,
                user = user,
                time = time,

            }); ;
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<takeaway>>(data);
            File.WriteAllText(@"takeaway.json", jsonString);
        }

        private static List<takeaway> gettakeawayList()
        {
            string jsonString = File.ReadAllText(@"takeaway.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<takeaway>>(jsonString);
            return data;
        }
    }
}
