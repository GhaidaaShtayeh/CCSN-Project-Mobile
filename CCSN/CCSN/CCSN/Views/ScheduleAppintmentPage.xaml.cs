using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using CCSN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleAppintmentPage : ContentPage
    {
        AppintmentService scheduleAppointmentServices = new AppintmentService();
        public ScheduleAppintmentPage()
        {
            InitializeComponent();

            BindingContext = new ScheduleAppointmentPageModelView();
        }
        public void AddAppointment_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success..!", "Appointment added successfully", "Ok");
        }
        
    }
}