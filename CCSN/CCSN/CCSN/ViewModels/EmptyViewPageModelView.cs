using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class EmptyViewPageModelView : BindableObject
    {
        public string AppointmentNumber { get; set; }
        public string AppointmentPatientName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string FollowUpDate { get; set; }
        public string FollowUpTools { get; set; }
        public string FollowUpGoals { get; set; }
        public string FollowUpAddNote { get; set; }
    }
}
