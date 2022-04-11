using CCSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAppointment : ContentPage
    {
        Appoitment appoitment;
        AppintmentService ScheduleAppintmentService;
        public EditAppointment(Appoitment appoitment)
        {
            InitializeComponent();
            BindingContext = appoitment;
            ScheduleAppintmentService = new AppintmentService();
        }
        
      /*  public async void DeleteScheduleApointment(object sender, EventArgs e)
        {
            await ScheduleAppintmentService.DeleteScheduleAppointment(appoitment.AppointmentPatientName,appoitment.AppointmentDate,
                                                             appoitment.AppointmentTime);
            await Navigation.PushAsync(new AppointmentPage());

        }*/
    }
}