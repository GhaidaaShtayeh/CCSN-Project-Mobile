using CCSN.Models;
using CCSN.Services;
using CCSN.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class PatientListPageModelView : BaseViewModel
    {
        private ObservableCollection<Patient> _Patient = new ObservableCollection<Patient>();

        public ObservableCollection<Patient> Patients { get => _Patient; set => SetProperty(ref _Patient, value, nameof(Patients)); }

        

        private ICommand _Appearing;
        private Patient _SelectedPatient;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }


        public PatientListPageModelView()
        {

            Appearing = new AsyncCommand(async () => await LoadData());
        }

        async Task LoadData()
        {
            Patients = new ObservableCollection<Patient>((List<Patient>)await PatientService.GetUserPatients());

        }

        public Patient SelectedPatient
        {
            get => _SelectedPatient;
            set
            {
                if (value != null)
                {
                    App.Current.MainPage = new NavigationPage(new Views.PatientProfileDetailsPage(value));
                }
                _SelectedPatient = value;
                OnPropertyChanged();
            }
        }
    }
}
