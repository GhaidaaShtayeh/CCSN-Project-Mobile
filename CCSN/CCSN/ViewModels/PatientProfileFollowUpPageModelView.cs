using CCSN.Models;
using CCSN.Services;
using CCSN.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class PatientProfileFollowUpPageModelView : BaseViewModel
    {
        private ObservableCollection<Appoitment> _Appoitments = new ObservableCollection<Appoitment>();
        private Appoitment _SelectedFollow;

        public ObservableCollection<Appoitment> Appoitments { get => _Appoitments; set => SetProperty(ref _Appoitments, value, nameof(Appoitments)); }


        private ICommand _Appearing;
        private ICommand _deleteAppointement;
        private ICommand _newFollowUP;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }
        public ICommand NewFollowUP { get => _newFollowUP; set => SetProperty(ref _newFollowUP, value, nameof(NewFollowUP)); }
        public ICommand DeleteAppointement { get => _deleteAppointement; set => SetProperty(ref _deleteAppointement, value, nameof(DeleteAppointement)); }

        public PatientProfileFollowUpPageModelView()
        {
            Appearing = new AsyncCommand(async () => await LoadData());
            DeleteAppointement = new AsyncCommand<Appoitment>(async (appoitment) => await DeleteAppointementPerforme(appoitment));
            NewFollowUP = new AsyncCommand(async () => await App.Current.MainPage.Navigation.PushAsync((new AddNewFollowPage())));
        }

        private async Task DeleteAppointementPerforme(Appoitment appoitment)
        {
            var confirme = await App.Current.MainPage.DisplayAlert("confirme", "Are you sure you want to delete Appointmet ? ", "yes", "no");
            if (confirme)
            {
                AppintmentService appintmentService = new AppintmentService();
                await appintmentService.DeleteFollowup(appoitment.PatientID, appoitment.ID);
                await App.Current.MainPage.DisplayAlert("Delted", "The patient Deleteed", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        async Task LoadData()
        {
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAppointmentsByDate(null));

        }

        public Appoitment SelectedFollow
        {
            get => _SelectedFollow;
            set
            {
                if (value != null)
                     App.Current.MainPage.Navigation.PushAsync((new Views.EditFollowPage(value)));
                OnPropertyChanged();
            }
        }
    }
}
