using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CCSN.Common
{
    public class PreferencesConfig
    {
        public static string Id
        {
            get { return Preferences.Get("Id", string.Empty); }
            set { Preferences.Set("Id", value); }
        }
    }
}
