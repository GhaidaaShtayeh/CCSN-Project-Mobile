using CCSN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CCSN.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CCSN.ViewModels
{
    public class EditFollowModelView : BaseViewModel
    {
        private Appoitment _Appoitment;

        private ICommand _EditFollowup;

        public Appoitment Appoitment { get => _Appoitment; set => SetProperty(ref _Appoitment, value, nameof(Appoitment)); }
        public ICommand EditFollowup { get => _EditFollowup; set => SetProperty(ref _EditFollowup, value, nameof(EditFollowup)); }


        public EditFollowModelView(Appoitment appoitment)
        {
            Appoitment = appoitment;
            EditFollowup = new Command(async () => await EditAppointment());
                
        }

        public  async Task EditAppointment()
        {
            AppintmentService AppintmentService = new AppintmentService();

            await AppintmentService.EditFollowup(Appoitment, Appoitment.PatientID, Appoitment.ID);
            await App.Current.MainPage.DisplayAlert("Edited", "The Appointment Edited", "Ok");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
