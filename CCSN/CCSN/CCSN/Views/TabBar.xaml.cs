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

            var navigationPageHome = new NavigationPage(new HomePage());
            navigationPageHome.IconImageSource = "https://freepikpsd.com/file/2019/10/black-home-icon-png-3-Transparent-Images.png";
            navigationPageHome.Title = "Home";

            var navigationPagePatients = new NavigationPage(new PatientsListPage());
            navigationPagePatients.IconImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Noun_Project_people_icon_3376085.svg/1024px-Noun_Project_people_icon_3376085.svg.png";
            navigationPagePatients.Title = "Patients";

            var navigationPageAppointment = new NavigationPage(new AppointmentPage());
            navigationPageAppointment.IconImageSource = "https://cdn2.iconfinder.com/data/icons/calendar-35/50/5-512.png";
            navigationPageAppointment.Title = "Patients";

            Children.Add(navigationPageHome);
            Children.Add(navigationPagePatients);
            Children.Add(navigationPageAppointment);


        }

    }
}