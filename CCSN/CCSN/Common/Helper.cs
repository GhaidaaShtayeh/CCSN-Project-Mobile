using System;
using System.Collections.Generic;
using System.Text;

namespace CCSN.Common
{
    public class Helper
    {
        public static string FirebaseUrl { get => "https://ccsn-fed2d-default-rtdb.firebaseio.com/"; }

        public static string GenerateKey(int lenght)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[lenght];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
