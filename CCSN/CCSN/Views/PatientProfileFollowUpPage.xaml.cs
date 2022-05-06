using CCSN.Models;
using CCSN.Services;
using CCSN.ViewModels;
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
        public PatientProfileFollowUpPage(Patient patient)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new PatientProfileFollowUpPageModelView(patient);

        }
    }
}