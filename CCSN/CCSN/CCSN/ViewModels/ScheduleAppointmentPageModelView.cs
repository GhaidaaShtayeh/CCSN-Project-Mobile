using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CCSN.ViewModels
{
    internal class ScheduleAppointmentPageModelView : BindableObject
    {
        public ScheduleAppointmentPageModelView()
        {
            InitializeComponent();

            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(4, 15, 26)
            };
        }
        public void CalendarView_DateSelectionChanged(object sender, EventArgs arg)
        {
            DisplayAlert("Date Available", calendar.SelectedDates.ToString(), "OK");

        }

    }
}
