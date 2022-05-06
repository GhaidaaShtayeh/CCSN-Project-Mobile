using System;
using Plugin.Settings;

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
        public static class UserSettings
        {
            static Plugin.Settings.Abstractions.ISettings AppSettings
            {
                get
                {
                    return CrossSettings.Current;
                }
            }
            public static string Name
            {
                get => AppSettings.GetValueOrDefault(nameof(Name), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(Name), value);
            }
            public static string MobileNumber
            {
                get => AppSettings.GetValueOrDefault(nameof(MobileNumber), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(MobileNumber), value);
            }
            public static string Email
            {
                get => AppSettings.GetValueOrDefault(nameof(Email), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(Email), value);
            }
            public static string ID
            {
                get => AppSettings.GetValueOrDefault(nameof(ID), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(ID), value);
            }
            public static void ClearAllData()
            {
                AppSettings.Clear();
            }
        }
    }
}
