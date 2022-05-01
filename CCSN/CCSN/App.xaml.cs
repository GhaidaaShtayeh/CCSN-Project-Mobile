using CCSN.Common;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new Views.TabBar());
            // MainPage = new Views.HomePage();
            if (PreferencesConfig.Id == string.Empty)
                MainPage = new NavigationPage(new Views.LogInPage());
            else
                MainPage = new NavigationPage(new Views.TabBar());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
