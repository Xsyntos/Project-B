using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Checker
    {
        // Check receives a string number and returns a string text
        public static string Check(string number)
        {
            string text = number.Length < 14 ? "Error: too short!" : number.Length > 14 ? "Error: too long!" : "Good enough!";
            return text;
        }
    }
}
