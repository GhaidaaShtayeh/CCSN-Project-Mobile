using CCSN.Models;
using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class EditAppointmentViewModel : BaseViewModel
    {
        private Appoitment _appoitment;
        //  private DateTime _selectedDate;
        //private TimeSpan _selectedTime;
        public Appoitment Appoitment { get => _appoitment; set => SetProperty(ref _appoitment, value, nameof(Appoitment)); }

        private ICommand _editAppoitment;

        public ICommand EditAppoitment { get => _editAppoitment; set => SetProperty(ref _editAppoitment, value, nameof(EditAppoitment)); }

        public EditAppointmentViewModel(Appoitment appoitment)
        {
            Appoitment = appoitment;

            EditAppoitment = new Command(async () => await EditAppoitmentPerforme());
        }



        private async Task EditAppoitmentPerforme()
        {
            var confirm = await App.Current.MainPage.DisplayAlert("confirm", "Are you sure u want to edit ? ", "yes", "no");
            if (confirm)
            {
                AppintmentService AppintmentService = new AppintmentService();
                await AppintmentService.EditApp(Appoitment, Appoitment.PatientID, Appoitment.ID);
                Console.Write(Appoitment);
                await App.Current.MainPage.DisplayAlert("Edited", "The Appoitment Edited", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }


    }
}