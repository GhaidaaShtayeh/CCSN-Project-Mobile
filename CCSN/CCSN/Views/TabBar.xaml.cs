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
    public partial class TabBar : TabbedPage
    {
        public TabBar()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            var navigationPageHome = new NavigationPage(new HomePage())
            { BarBackgroundColor = Color.FromHex("#1EA6D6") };
            navigationPageHome.IconImageSource = "https://www.iconsdb.com/icons/preview/white/home-xxl.png";
            navigationPageHome.Title = "Home";

            var navigationPagePatients = new NavigationPage(new PatientsListPage())
            { BarBackgroundColor = Color.FromHex("#1EA6D6") };
            navigationPagePatients.IconImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Noun_Project_people_icon_3376085.svg/1024px-Noun_Project_people_icon_3376085.svg.png";
            navigationPagePatients.Title = "Patients";

            var navigationPageAppointment = new NavigationPage(new AppointmentPage())
            { BarBackgroundColor = Color.FromHex("#1EA6D6") }; 
            navigationPageAppointment.IconImageSource = "https://cdn2.iconfinder.com/data/icons/calendar-35/50/5-512.png";
            navigationPageAppointment.Title = "Appointment";

            Children.Add(navigationPageHome);
            Children.Add(navigationPagePatients);
            Children.Add(navigationPageAppointment);


        }

    }
}