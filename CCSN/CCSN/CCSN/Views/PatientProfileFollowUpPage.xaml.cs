using CCSN.Models;
using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientProfileFollowUpPage : ContentPage
    {
        public PatientProfileFollowUpPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
             Navigation.PushAsync(new AddNewFollowPage());

        }


         private async void ItemImageButton_Clicked(object sender, EventArgs e)
        {
            var appoitment = (Appoitment)((ImageButton)sender).CommandParameter;
            AppintmentService appintmentService = new AppintmentService();
            await appintmentService.DeleteFollowup(appoitment.PatientID, appoitment.ID);
            await DisplayAlert("Delted", "The patient Deleteed", "Ok");
            await Navigation.PushAsync(new PatientProfileFollowUpPage());
        }
    }
}