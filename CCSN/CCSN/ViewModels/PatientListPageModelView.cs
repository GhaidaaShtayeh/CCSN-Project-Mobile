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
        private ICommand _deletePatient;

        public ObservableCollection<Patient> Patients { get => _Patient; set => SetProperty(ref _Patient, value, nameof(Patients)); }


        public INavigation Navigation { get; set; }

        private ICommand _Appearing;
        private Patient _SelectedPatient;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }
        public ICommand ScheduleBtnClicked{ get; }
        public ICommand DeletePatient { get => _deletePatient; set => SetProperty(ref _deletePatient, value, nameof(DeletePatient)); }
        public ICommand ProfileBtnClicked { get; }
        public PatientListPageModelView(INavigation navigation)
        {

            Appearing = new AsyncCommand(async () => await LoadData());
            this.Navigation = navigation;
            this.ScheduleBtnClicked = new Command(async () => await GotoSchedulePatient());
            this.ProfileBtnClicked = new Command(async () => await GotoSpecalistProfile());
            DeletePatient = new Command<Patient>(async (o) => await DeletePatiebtPerforme(o));

        }
        private async Task DeletePatiebtPerforme(Patient patient)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "are you sure you want to delete ?", "yes", "no");
            if (confirm)
            {
                PatientService patientService = new PatientService();
                await patientService.DeletePatient(patient.ID);
                await App.Current.MainPage.DisplayAlert("Delted", "The patient Deleteed", "Ok");
                //await App.Current.MainPage.Navigation.PopAsync();

                //   await App.Current.MainPage.Navigation.PushAsync(new PatientsListPage());

            }
        }
        public async Task GotoSchedulePatient()
        {
            /////
            await App.Current.MainPage.Navigation.PushAsync(new AddPatientPage());

        }
        public async Task GotoSpecalistProfile()
        {
            /////
            await App.Current.MainPage.Navigation.PushAsync(new SpecalistProfilePage());

        }

        async Task LoadData()
        {
            IsLoading = true;
            Patients = new ObservableCollection<Patient>((List<Patient>)await PatientService.GetUserPatients());
            IsLoading = false;


        }

        public Patient SelectedPatient
        {
            get => _SelectedPatient;
            set
            {
                if (value != null)
                {
                     App.Current.MainPage.Navigation.PushAsync(new TopBarProfile(value));
                }
                _SelectedPatient = value;
                OnPropertyChanged();
            }
        }
    }
}
