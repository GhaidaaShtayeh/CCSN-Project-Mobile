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
    public partial class EditFollowPage : ContentPage
    {
        Appoitment Appoitment;
        AppintmentService FollowUpService;
        public EditFollowPage(Appoitment appoitment)
        {
            InitializeComponent();
            BindingContext = appoitment;
            FollowUpService = new AppintmentService();
            Appoitment = appoitment;
            DatePcker.Date = Appoitment.AppointmentDate;
            Tools.Text = Appoitment.FollowUpTools;
            Goals.Text = Appoitment.FollowUpGoals;
            Notes.Text = Appoitment.FollowUpAddNote;

            EditPatientClick();
           
           
        }

        public async void EditAppointment()
        {
            AppintmentService AppintmentService = new AppintmentService();
            Appoitment.AppointmentDate = DatePcker.Date;
            Appoitment.FollowUpTools = Tools.Text;
            Appoitment.FollowUpGoals = Goals.Text;
            Appoitment.FollowUpAddNote = Notes.Text;
            

            await AppintmentService.EditAppointment(Appoitment);
            await DisplayAlert("Edited", "The Patient Edited", "Ok");
            await Navigation.PushAsync(new PatientProfileFollowUpPage());

        }

        void EditPatientClick()
        {
            save.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    EditAppointment();

                })
            });
        }

       /* public async void DeleteFollowUpApointment(object sender, EventArgs e)
        {
            await FollowUpService.DeleteFollowUpAppointment(Appoitment.FollowUpDate, Appoitment.FollowUpTools,
                                                             Appoitment.FollowUpGoals, Appoitment.FollowUpAddNote);
            await Navigation.PushAsync(new PatientProfileFollowUpPage());
           
        }*/
    }
}