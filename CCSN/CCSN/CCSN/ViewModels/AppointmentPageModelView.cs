﻿using CCSN.Models;
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
    public class AppointmentPageModelView : BaseViewModel
    {
        private AppintmentService _AppointmentService;
        private ObservableCollection<Appoitment> _Appoitments = new ObservableCollection<Appoitment>();
        private Appoitment _SelectedAppoitment;

        public ObservableCollection<Appoitment> Appoitments { get => _Appoitments; set => SetProperty(ref _Appoitments, value, nameof(Appoitments)); }
        public Appoitment SelectedAppoitment
        {
            get => _SelectedAppoitment;
            set
            {
                SetProperty(ref _SelectedAppoitment, value, nameof(SelectedAppoitment));
                App.Current.MainPage.Navigation.PushAsync(new EditAppointment(value));
            }
        }


        private ICommand _Appearing;

        public ICommand Appearing { get => _Appearing; set => SetProperty(ref _Appearing, value, nameof(Appearing)); }

        public AppointmentPageModelView()
        {

            Appearing = new AsyncCommand(async () => await LoadData());
        }

        async Task LoadData()
        {
            Appoitments = new ObservableCollection<Appoitment>(await AppintmentService.GetUserAllAppointments());

        }
    }
}
