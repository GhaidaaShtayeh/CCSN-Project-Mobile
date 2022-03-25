using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CCSN.Services;
namespace CCSN
{
    public partial class MainPage : ContentPage
    {
        SpecalistService specalistService = new SpecalistService();
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var Specalist = await specalistService.GetAll();
            SpecalistListView.ItemsSource = Specalist;

        }
    }
}
