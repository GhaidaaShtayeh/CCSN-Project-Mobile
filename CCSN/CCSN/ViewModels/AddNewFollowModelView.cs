using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CCSN.Models;
using CCSN.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class AddNewFollowModelView : BaseViewModel
    {
        public string FollowUpDate { get; set; }
        public string FollowUpTools { get; set; }
        public string FollowUpGoals { get; set; }
        public string FollowUpAddNote { get; set; }

        private AppintmentService _services;
        public Command AddFollowUpCommand { get; }
        private ObservableCollection<Appoitment> _FollowUp = new ObservableCollection<Appoitment>();
        public ObservableCollection<Appoitment> FollowUp
        {
            get { return _FollowUp; }
            set
            {
                _FollowUp = value;
                OnPropertyChanged();
            }

        }
        public AddNewFollowModelView()
        {
            _services = new AppintmentService();
            AddFollowUpCommand = new Command(async () => await addFollowUpAsync(FollowUpDate, FollowUpTools, FollowUpGoals, FollowUpAddNote));

        }
        public async Task addFollowUpAsync(string FollowUpDate, string FollowUpTools, string FollowUpGoals, string FollowUpAddNote)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "Are you sure to add new follow ? ", "yes", "no");
            if (confirm)
            {
               // await _services.addFollowUp(FollowUpDate, FollowUpTools, FollowUpGoals, FollowUpAddNote);
                await App.Current.MainPage.DisplayAlert("Error", "Done", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

    }
}