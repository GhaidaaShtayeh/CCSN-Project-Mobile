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


        private ICommand _Appearing;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }

        public HomePageModelView()
        {

            Appearing = new AsyncCommand(async () => await LoadData());
            var now = DateTime.Now.ToString();
            var x = JsonConvert.SerializeObject(DateTime.Now);
            Console.WriteLine(x);
        }

        async Task LoadData()
        {
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAppointments());

        }


    }
}
