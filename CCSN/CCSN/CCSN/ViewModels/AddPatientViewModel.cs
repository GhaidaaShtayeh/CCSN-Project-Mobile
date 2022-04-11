using CCSN.Models;
using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CCSN.Views;


namespace CCSN.ViewModels
{
    public class AddPatientViewModel : BaseViewModel
    {

        private string _ID;
        public string ID
        {
            set
            {
                this._ID = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ID;
            }
        }

        private string _PatientAddress;
        public string PatientAddress
        {
            set
            {
                this._PatientAddress = value;
                OnPropertyChanged();
            }
            get
            {
                return this._PatientAddress;
            }
        }
        private string _PatientName;
        public string PatientName
        {
            set
            {
                this._PatientName = value;
                OnPropertyChanged();
            }
            get { return this._PatientName; }
        }
        private string _PatientBirthday;
        public string PatientBirthday
        {
            set
            {
                this._PatientBirthday = value;
                OnPropertyChanged();

            }
            get { return this._PatientBirthday; }
        }
        private string _PatientGender;
        public string PatientGender
        {
            set
            {
                this._PatientGender = value;
                OnPropertyChanged();
            }
            get { return this._PatientGender; }
        }

        private string _PatientGenticsDiseses;
        public string PatientGenticsDiseses
        {
            set
            {
                this._PatientGenticsDiseses = value;
                OnPropertyChanged();
            }
            get { return this._PatientGenticsDiseses; }
        }
        private string _PatientHeight;
        public string PatientHeight
        {
            set
            {
                this._PatientHeight = value;
                OnPropertyChanged();
            }
            get { return this._PatientHeight; }
        }
        private string _PatientMobileNo;
        public string PatientMobileNo
        {
            set
            {
                this._PatientMobileNo = value;
                OnPropertyChanged();
            }
            get { return this._PatientMobileNo; }
        }

        private string _PatientWeight;
        public string PatientWeight
        {
            set
            {
                this._PatientWeight = value;
                OnPropertyChanged();
            }
            get { return this._PatientWeight; }
        }
      
        public List<Appoitment> Appointments = new List<Appoitment>();

        private bool _Result;
        public bool Result
        {
            set { this._Result = value; OnPropertyChanged(); }
            get { return this._Result; }
        }

        public Command AddCommand { get; set; }
        public AddPatientViewModel()
        {

            AddCommand = new Command(async () => await AddPatientCommandAsync());
        }

        private async Task AddPatientCommandAsync()
        {

            try
            {
                var patientServices = new PatientService();
                Result = await patientServices.AddPatients(ID, PatientAddress, PatientBirthday, PatientGender, PatientGenticsDiseses, PatientHeight, PatientMobileNo, PatientName, PatientWeight, Appointments);


                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("message", "Patient Added", "ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Patient Exsist", "ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", ex.Message, "ok");

            }
        }




    }
}
