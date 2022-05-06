using CCSN.Models;
using CCSN.Services;
using CCSN.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class AppointmentPageModelView : BaseViewModel
    {
        private ObservableCollection<Appoitment> _Appoitments = new ObservableCollection<Appoitment>();
        public INavigation Navigation { get; set; }

        public ObservableCollection<Appoitment> Appoitments { get => _Appoitments; set => SetProperty(ref _Appoitments, value, nameof(Appoitments)); }


        private ICommand _Appearing;
        private ICommand _deleteAppointement;
        private Appoitment _SelectedAppointment;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }
        public ICommand DeleteAppointement { get => _deleteAppointement; set => SetProperty(ref _deleteAppointement, value, nameof(DeleteAppointement)); }

        public AppointmentPageModelView(INavigation navigation)
        {

            Appearing = new AsyncCommand(async () => await LoadData());
            this.Navigation = navigation;
            this.ScheduleBtnClicked = new Command(async () => await GotoScheduleAppointment());
            DeleteAppointement = new Command<Appoitment>(async (o) => await DeleteAppointementPerforme(o));
        }

        private async Task LoadData()
        {
            IsLoading = true;
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAppointmentsByDate(null, "up"));
            IsLoading = false;
        }

        public async Task GotoScheduleAppointment()
        {
            /////
            await App.Current.MainPage.Navigation.PushAsync(new ScheduleAppintmentPage());

        }

        public ICommand ScheduleBtnClicked
        {
            protected set;
            get;
        }

        private async Task DeleteAppointementPerforme(Appoitment appoitment)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "are you sure you want to delete", "yes", "no");
            if (confirm)
            {
                AppintmentService appintmentService = new AppintmentService();
                await appintmentService.DeleteFollowup(appoitment.PatientID, appoitment.ID);
                Appoitments.Remove(appoitment);
                await App.Current.MainPage.DisplayAlert("Delted", "The patient Deleteed", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new AppointmentPage());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanges([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        public Appoitment SelectedAppointment
        {
            get => _SelectedAppointment;
            set
            {
                if (value != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new EditAppointment(value));
                }
                _SelectedAppointment = value;
                OnPropertyChanged();
            }
        }
    }
}