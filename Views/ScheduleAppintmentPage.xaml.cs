using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CCSN.ViewModels;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class ScheduleAppintmentPage : ContentPage
    {
        AppintmentService appointmentServices = new AppintmentService();

        public ScheduleAppintmentPage()
        {
            InitializeComponent();

            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(4, 15, 26)
            };
            BindingContext = new ScheduleAppointmentPageModelView();
        }
       
    }
}