using CCSN.Models;
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
    public partial class TopBarProfile : TabbedPage
    {
        public TopBarProfile(Patient patient )
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);

            var navigationDetails = new NavigationPage(new PatientProfileDetailsPage(patient));
            navigationDetails.Title = "Patient Details";

            var navigationFollow = new NavigationPage(new PatientProfileFollowUpPage(patient));
            navigationFollow.Title = "Patient Follow Up";


            Children.Add(navigationDetails);
            Children.Add(navigationFollow);
        }
    }
}