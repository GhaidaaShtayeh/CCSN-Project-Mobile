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
    public partial class PatientProfileDetailsPage : ContentPage
    {


        Patient Patient ;
        public PatientProfileDetailsPage(Patient cat)
        {
            InitializeComponent();

            Patient = cat;
            PatientNameEntry.Text = cat.PatientName;
            MobileEntry.Text = cat.PatientMobileNO;
            PatientGenderEntry.Text = cat.PatientGender;
            PatientAddressEntry.Text = cat.PatientAddress;
            PatientBirthdayEntry.Text = cat.PatientBirthday;
            PatientHeightEntry.Text = cat.PatientHeight;
            PatientWeightEntry.Text = cat.PatientWeight;
            PatientGenticesDisesesEntry.Text = cat.PatientGenticesDiseses;
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

            await PatientService.EditPatient(Patient,Patient.ID);
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