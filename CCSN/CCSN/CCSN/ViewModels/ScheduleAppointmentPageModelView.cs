using System;
using CCSN.Models;
using CCSN.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CCSN.ViewModels
{
    internal class ScheduleAppointmentPageModelView : BindableObject
    {
        TimeSpan appointmentTime = DateTime.Now.TimeOfDay; //time picker 
        public TimeSpan AppointmentTime
        {
            get { return appointmentTime; }
            set
            {
                if (appointmentTime != value)
                {
                    appointmentTime = value;
                    OnPropertyChanged("AppointmentTime");
                }
            }
        }

        public DateTime AppointmentDate { get; set; }//date picker 
        public string AppointmentPatientName { get; set; } //picker 

        private AppintmentService services;
        public Command AddScheduleCommand { get; }
        private ObservableCollection<Appoitment> _Schedule = new ObservableCollection<Appoitment>();
        public ObservableCollection<Appoitment> Schedules
        {
            get { return _Schedule; }
            set
            {
                _Schedule = value;
                OnPropertyChanged();
            }

        }
        public ScheduleAppointmentPageModelView()
        {
            services = new AppintmentService();
            Schedules = services.getScheduleAppointment();
            AddScheduleCommand = new Command(async () => await addScheduleAppointmentAsync(AppointmentPatientName, AppointmentDate.Date, AppointmentTime));

        }
        public async Task addScheduleAppointmentAsync(string AppointmentPatientName, DateTime AppointmentDate, TimeSpan AppointmentTime)
        {
            await services.addScheduleAppointment(AppointmentPatientName, AppointmentDate, AppointmentTime);

        }

    }
    
}

