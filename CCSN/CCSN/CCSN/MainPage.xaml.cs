using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CCSN.Services;
using CCSN.Models;
namespace CCSN
{
    public partial class MainPage : ContentPage
    {
        SpecalistService specalistService;
        List<Specalist> specs;
        public MainPage()
        {
            InitializeComponent();
            specs = new List<Specalist>();
            specalistService = new SpecalistService();
            Button_ClickedAsync();

        }


        async private void Button_ClickedAsync()
        {
            specs = await specalistService.GetAll();
            SpecalistListView.ItemsSource = specs;
            specs.ForEach(spec => Console.WriteLine(spec.Name));
        }
    }
}
