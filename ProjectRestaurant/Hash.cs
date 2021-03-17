using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace ProjectRestaurant
{
    public class Hash
    {
        // Get function receives an input and returns a hash of the input.
        public static string Encrypt(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            var hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (var x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public string Decrypt()
        {
            return "";
        }
    }
}
