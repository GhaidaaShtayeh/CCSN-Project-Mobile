using CCSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CCSN.ViewModels;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientProfileDetailsPage : ContentPage
    {
        public PatientProfileDetailsPage(Patient patient)
        {
            InitializeComponent();
        
            BindingContext =new PatientProfileDetailsPageModelView(patient);

        }
    }
}