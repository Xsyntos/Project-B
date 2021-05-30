using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ProjectRestaurant
{
    [System.Serializable]
    public class table
    {

        public int Id { get; set; }
        public int capacity { get; set; }
        public bool vip { get; set; }

        public string stringy()
        {
            if (this.vip)
            {
                return $"table of {this.capacity} VIP";
            }
            return $"table of {this.capacity}";
        }

    }

    class json_table
    {
        public static void tableInit()
        {
            if (!File.Exists(@"table.json"))
            {
                List<table> data = new List<table>();
                for (int i = 1; i <= 8; i++)
                {
                    data.Add(new table()
                    {
                        Id = i,
                        capacity = 2,
                        vip = true

                    });
                }
                for (int i = 9; i <= 14; i++)
                {
                    data.Add(new table()
                    {
                        Id = i,
                        capacity = 4,
                        vip = true

                    });
                }
                string jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<table>>(data);
                File.WriteAllText(@"table.json", jsonString);
            }
        }
        public static void addTable(int cap = 2, bool Vip = false)
        {
            var data = getTableList();
            data.Add(new table()
            {
                Id = data[data.Count - 1].Id + 1,
                capacity = cap,
                vip = Vip

            }); ;
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<table>>(data);
            File.WriteAllText(@"table.json", jsonString);
        }
        public static void removeTable(int id)
        {
            var data = getTableList();
            data.RemoveAll(i => i.Id == id);
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<table>>(data);
            File.WriteAllText(@"table.json", jsonString);
        }
        public static void removeTable(table t)
        {
            removeTable(t.Id);
        }
        public static void changeVIP(int id)
        {
            var data = getTableList();
            foreach(var i in data)
            {
                if (i.Id == id)
                {
                    i.vip = !i.vip;
                }
            }
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<table>>(data);
            File.WriteAllText(@"table.json", jsonString);
        }
        public static void changeCap(int id, int newCap) 
        {
            var data = getTableList();
            foreach (var i in data)
            {
                if (i.Id == id)
                {
                    i.capacity = newCap;
                }
            }
            var jsonString = JsonSerializer.Serialize<System.Collections.Generic.List<table>>(data);
            File.WriteAllText(@"table.json", jsonString);
        }

        public static List<table> getTableList()
        {
            string jsonString = File.ReadAllText(@"table.json");
            var data = JsonSerializer.Deserialize<System.Collections.Generic.List<table>>(jsonString);
            return data;
        }

        public static table[] getFreeTable(DateTime date)
        {
         //   var list = new List<table>();
            var tables = getTableList();
            var tablelist = new List<table>();
            var res = json_reservation.reservationsofdate(date);
            tablelist.AddRange(tables);
           foreach (var i in res) {
                foreach (var y in tables)
                {
                    if((y.Id == i.table.Id))
                    {
                        tablelist.Remove(y);
                    }
                }
            }
            return tablelist.ToArray();

        }
        public static table getTableFromId(int id)
        {
            var data = getTableList();
            foreach(var i in data) {
                if(i.Id == id)
                {
                    return i;
                }
            }
            return new table();
        }
    }
}
