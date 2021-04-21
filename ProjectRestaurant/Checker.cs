using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRestaurant
{
    class Checker
    {
        // Check receives a string number and returns a string text
        public static bool Check(string number)
        {
            bool text = number.Length < 16 ? false : number.Length > 16 ? false : true;
            return text;
        }
    }
}
