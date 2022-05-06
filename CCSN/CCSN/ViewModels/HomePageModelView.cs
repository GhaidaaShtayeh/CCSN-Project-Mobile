using CCSN.Models;
using CCSN.Services;
using CCSN.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class HomePageModelView : BaseViewModel
    {
        private ObservableCollection<Appoitment> _Appoitments = new ObservableCollection<Appoitment>();


        public ObservableCollection<Appoitment> Appoitments { get => _Appoitments; set => SetProperty(ref _Appoitments, value, nameof(Appoitments)); }

        private ObservableCollection<Appoitment> _Appoitments2 = new ObservableCollection<Appoitment>();

        public ObservableCollection<Appoitment> Appoitments2 { get => _Appoitments2; set => SetProperty(ref _Appoitments2, value, nameof(Appoitments2)); }

        private ICommand _Appearing;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }

        public ICommand ProfileBtnClicked { get; }
        public INavigation Navigation { get; set; }

        public HomePageModelView()
        {
            Appearing = new AsyncCommand(async () => await LoadData());

            var now = DateTime.Now.ToString();
            var x = JsonConvert.SerializeObject(DateTime.Now);
            Console.WriteLine(x);
        }

        async Task LoadData()
        {
            IsLoading = true;
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAppointmentsByDate(DateTime.Now, ""));
            Appoitments2 = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAppointmentsByDate(DateTime.Now.AddDays(1), ""));
            IsLoading = false;

        }
        public HomePageModelView(INavigation navigation)
        {
            Appearing = new AsyncCommand(async () => await LoadData());
            this.Navigation = navigation;
            this.ProfileBtnClicked = new Command(async () => await GotoSpecalistProfile());

        }
        public async Task GotoSpecalistProfile()
        {
            /////
            await App.Current.MainPage.Navigation.PushAsync(new SpecalistProfilePage());

        }
    }
}