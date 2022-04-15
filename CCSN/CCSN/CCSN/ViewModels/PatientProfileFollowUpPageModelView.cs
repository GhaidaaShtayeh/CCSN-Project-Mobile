using CCSN.Models;
using CCSN.Services;
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
        private AppintmentService _AppointmentService;
        private ObservableCollection<Appoitment> _Appoitments = new ObservableCollection<Appoitment>();
        private Appoitment _SelectedFollow;

        public ObservableCollection<Appoitment> Appoitments { get => _Appoitments; set => SetProperty(ref _Appoitments, value, nameof(Appoitments)); }


        private ICommand _Appearing;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }

        public PatientProfileFollowUpPageModelView()
        {

            Appearing = new AsyncCommand(async () => await LoadData());
        }

        async Task LoadData()
        {
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAllAppointments());

        }
        public Appoitment SelectedFollow
        {
            get => _SelectedFollow;
            set
            {
                if (value != null)
                {
                    App.Current.MainPage = new NavigationPage(new Views.EditFollowPage(value));
                }
                _SelectedFollow = value;
                OnPropertyChanged();
            }
        }
    }
}
