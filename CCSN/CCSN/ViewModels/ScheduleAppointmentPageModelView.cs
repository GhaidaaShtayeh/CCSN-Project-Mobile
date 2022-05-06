using System;
using CCSN.Models;
using CCSN.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;

namespace CCSN.ViewModels
{

    public class ScheduleAppointmentPageModelView : BaseViewModel
    {
        private List<Patient> _patiens = new List<Patient>();
        private Patient _patienSelected;
        private DateTime _selectedDate;
        private TimeSpan _selectedTime;

        public List<Patient> Patients { get => _patiens; set => SetProperty(ref _patiens, value, nameof(Patients)); }
        public Patient PatienSelected { get => _patienSelected; set => SetProperty(ref _patienSelected, value, nameof(PatienSelected)); }
        public DateTime SelectedDate { get => _selectedDate; set => SetProperty(ref _selectedDate, value, nameof(SelectedDate)); }
        public TimeSpan SelectedTime { get => _selectedTime; set => SetProperty(ref _selectedTime, value, nameof(SelectedTime)); }



        private ICommand _appearing;
        private ICommand _add;

        public ICommand Appearing { get => _appearing; set => SetProperty(ref _appearing, value, nameof(Appearing)); }
        public ICommand Add { get => _add; set => SetProperty(ref _add, value, nameof(Add)); }

        public ScheduleAppointmentPageModelView()
        {
            Appearing = new Command(async () => await LoadData());
            Add = new Command(async () => await AddPerforme());
        }

        private async Task AddPerforme()
        {
            try
            {
                var confirm = await App.Current.MainPage.DisplayAlert("confirm", "Are you sure you want to add ? ", "yes", "no");
                var Result = await AppintmentService.addScheduleAppointment(PatienSelected.ID, PatienSelected.PatientName, SelectedDate, SelectedTime);
                if (confirm && Result)
                {
                    await App.Current.MainPage.DisplayAlert("message", "Appointment Added", "ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else if (confirm)
                {
                    await App.Current.MainPage.DisplayAlert("message", "No Appointment Added, Please check the date ", "ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("message", "No Appointment Added", "ok");
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Patient Name Filed Is Empty ", "ok");

            }
        }
            private async Task LoadData()
            {
                Patients = new List<Patient>(await PatientService.GetUserPatients());
            }

        }
    }

