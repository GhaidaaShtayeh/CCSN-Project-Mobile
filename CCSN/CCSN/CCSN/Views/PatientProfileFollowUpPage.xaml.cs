using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Models;
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

       /* public async void OnItemFollowUpSelected(object sender, ItemTappedEventArgs e)
        {
            var FollowUpAppointment = e.Item as Appoitment;
            if (FollowUpAppointment == null) return;
            await Navigation.PushAsync(new EditFollowPage(FollowUpAppointment));
            ListFollowUpAppointment.SelectedItem = null;
        }*/
    }
}