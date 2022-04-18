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
    public partial class PatientsListPage : ContentPage
    {
        public PatientsListPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPatientPage()); 
        }
        private async void ItemImageButton_Clicked(object sender, EventArgs e)
        {
            var patient = (Patient)((ImageButton)sender).CommandParameter;
            PatientService patientService = new PatientService();
            await patientService.DeletePatient(patient.ID);
            await DisplayAlert("Delted", "The patient Deleteed", "Ok");
            await Navigation.PushAsync(new PatientsListPage());
        }
    }
}