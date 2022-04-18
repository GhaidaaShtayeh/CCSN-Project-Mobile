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
    public partial class PatientProfileDetailsPage : ContentPage
    {

        Patient Patient;
        public PatientProfileDetailsPage(Patient patient)
        {
            InitializeComponent();
            Patient = patient;
            PatientNameEntry.Text = patient.PatientName;
            MobileEntry.Text = patient.PatientMobileNO;
            PatientGenderEntry.Text = patient.PatientGender;
            PatientAddressEntry.Text = patient.PatientAddress;
            PatientBirthdayEntry.Text = patient.PatientBirthday;
            PatientHeightEntry.Text = patient.PatientHeight;
            PatientWeightEntry.Text = patient.PatientWeight;
            PatientGenticesDisesesEntry.Text = patient.PatientGenticesDiseses;
            EditPatientClick();

        }

        public async void EditPatient()
        {
            PatientService PatientService = new PatientService();
            Patient.PatientName = PatientNameEntry.Text;
            Patient.PatientMobileNO = MobileEntry.Text;
            Patient.PatientGender = PatientGenderEntry.Text;
            Patient.PatientBirthday = PatientBirthdayEntry.Text;
            Patient.PatientAddress = PatientAddressEntry.Text;
            Patient.PatientHeight = PatientHeightEntry.Text;
            Patient.PatientWeight = PatientWeightEntry.Text;
            Patient.PatientGenticesDiseses = PatientGenticesDisesesEntry.Text;

            await PatientService.EditPatient(Patient, Patient.ID);
            await DisplayAlert("Edited", "The Patient Edited", "Ok");
            await Navigation.PushAsync(new PatientsListPage());

        }

        void EditPatientClick()
        {
            save.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    EditPatient();

                })
            });
        }
    }
}