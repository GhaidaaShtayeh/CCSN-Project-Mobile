using CCSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAppointment : ContentPage
    {
        private Appoitment appoitment;
        public EditAppointment(Appoitment cat)
        {
            InitializeComponent();
            appoitment = cat;
            NameEntry.Text = cat.AppointmentPatientName;
            EdtiCategoryClick();
        }
        public async void EditCategory()
        {
            AppintmentService appintmentService = new AppintmentService();
            appoitment.AppointmentPatientName = NameEntry.Text;

            //await appintmentService.E("406707265", appoitment);
            await DisplayAlert("Adding", "The Appointment Edited", "Ok");
            await Navigation.PopAsync();

        }

        void EdtiCategoryClick()
        {
            save.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    EditCategory();

                })
            });
        }
    }
}