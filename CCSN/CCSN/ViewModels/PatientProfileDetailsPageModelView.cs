using CCSN.Models;
using CCSN.Services;
using CCSN.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class PatientProfileDetailsPageModelView : BaseViewModel
    {
        private Patient _patient;

        public Patient Patient { get => _patient; set => SetProperty(ref _patient, value, nameof(Patient)); }

        private ICommand _editPatient;
        private ICommand _deletePatient;

        public ICommand EditPatient { get => _editPatient; set => SetProperty(ref _editPatient, value, nameof(EditPatient)); }

        public PatientProfileDetailsPageModelView(Patient patient)
        {
            Patient = patient;
            EditPatient = new Command(async () => await EditPatientPerforme());
        }

        private async Task EditPatientPerforme()
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "Are you sure u want to edit ? ", "yes", "no");
            if (confirm)
            {
                PatientService PatientService = new PatientService();
                await PatientService.EditPatient(Patient, Patient.ID);
                await App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.DisplayAlert("Edited", "The Patient Edited", "Ok");
            }
        }
    }
}
