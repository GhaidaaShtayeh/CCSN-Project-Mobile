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
            MainPage = new NavigationPage(new Views.LogInPage()) ;
            // MainPage = new Views.HomePage();
           
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
