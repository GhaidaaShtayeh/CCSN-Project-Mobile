using CCSN.Models;
using CCSN.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using CCSN.Services;
using static CCSN.Common.Helper;

namespace CCSN.ViewModels
{
    public class SpcalistProfilePageModelView : BaseViewModel
    {
        public INavigation _navigation;

        // get info 
        private Specalist _Specalist;

        public Specalist Specalist { get => _Specalist; set => SetProperty(ref _Specalist, value, nameof(Specalist)); }

        private ICommand _editSpecalist;
      

        public ICommand EditSpecalist { get => _editSpecalist; set => SetProperty(ref _editSpecalist, value, nameof(EditSpecalist)); }

        public SpcalistProfilePageModelView(Specalist specalist)
        {
            Specalist = specalist;
            EditSpecalist = new Command(async () => await EditSpecalistPerforme());
        }

        
        private async Task EditSpecalistPerforme()
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "Are you sure u want to edit ? ", "yes", "no");
            if (confirm)
            {
                SpecalistService SpecalistService = new SpecalistService();
                await SpecalistService.EditSpecalist(Specalist);
                await App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.DisplayAlert("Edited", "The Specalist Edited", "Ok");
            }
        }

        // log out system
        public ICommand LogoutCommand
        {
            get;
            private set;
        }
        public SpcalistProfilePageModelView(INavigation navigation)
        {
            _navigation = navigation;
            LogoutCommand = new Command(() => ResetUserInfo());
        }

        void ResetUserInfo()
        {
            _navigation.PushAsync(new LogInPage());
            UserSettings.ClearAllData();
        }

    }
}
