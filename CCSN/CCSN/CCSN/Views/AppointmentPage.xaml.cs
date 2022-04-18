using CCSN.Models;
using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentPage : ContentPage
    {
        public AppointmentPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScheduleAppintmentPage());

        }


        private async void ItemImageButton_Clicked(object sender, EventArgs e)
        {
            var appoitment = (Appoitment)((ImageButton)sender).CommandParameter;
            AppintmentService appintmentService = new AppintmentService();
            await appintmentService.DeleteAppointment(appoitment.PatientID, appoitment.ID);
            await DisplayAlert("Delted", "The Appointment Deleteed", "Ok");
            await Navigation.PushAsync(new AppointmentPage());
        }
    }
}