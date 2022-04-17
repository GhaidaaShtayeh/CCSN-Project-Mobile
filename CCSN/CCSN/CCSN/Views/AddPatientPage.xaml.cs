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
    public partial class AddPatientPage : ContentPage
    {
        public AddPatientPage()
        {
            InitializeComponent();
            AddPatientClick();
        }
            public async void addPatient()
            {
                PatientService patientService = new PatientService();
                Patient patient = new Patient();

            patient.ID = ID.Text;
            patient.PatientAddress = PatientAddress.Text;
            patient.PatientBirthday = PatientBirthday.Text;
            patient.PatientGender = PatientGender.Text;
            patient.PatientGenticesDiseses = PatientGenticsDiseses.Text;
            patient.PatientHeight = PatientHeight.Text;
            patient.PatientMobileNO = PatientMobileNo.Text;
            patient.PatientName=PatientName.Text;
            patient.PatientWeight=PatientWeight.Text;

               // Random rd = new Random();
                //int rand_num = rd.Next(1, 4000);
           // patient.ID = rand_num.ToString();
            try
            {
                await patientService.AddPatient(patient);
                await Application.Current.MainPage.DisplayAlert("message", "Patient Added", "ok");
               await Navigation.PushAsync(new PatientsListPage());
            }
            
        
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", ex.Message, "ok");

            }

        }
            void AddPatientClick()
            {
                save.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                    {
                        addPatient();

                    })
                });
            }
        }
    }