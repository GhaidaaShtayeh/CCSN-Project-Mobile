using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace CCSN.ViewModels
{
    public class LogInPageModelView :BaseViewModel
    {
        private string _ID;
        public string ID
        {
            set
            {
                this._ID = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ID;
            }
        }
        private string _password;

        public string password
        {
            set
            {
                this._password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._password;
            }
        }

        private bool _Result;
        public bool Result
        {
            set { this._Result = value; OnPropertyChanged(); }
            get { return this._Result; }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LogInPageModelView()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
          
        }

  

        private async Task LoginCommandAsync()
        {
            try
            {

                var userServ = new SpecalistService();
                Result = await userServ.LoginUser(ID, password);
                if (Result)
                {
                    Preferences.Set("ID", ID);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new Views.TabBar());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid user id or pass", "ok");

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }

        }
    }
}
