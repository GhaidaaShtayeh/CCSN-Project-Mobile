using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CCSN.Models;
using CCSN.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace CCSN.ViewModels
{
    internal class ScheduleAppointmentPageModelView : BindableObject
    {
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentPatientName { get; set; }

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
            AddScheduleCommand = new Command(async () => await addScheduleAppointmentAsync(AppointmentPatientName, AppointmentDate, AppointmentTime));

        }
        public async Task addScheduleAppointmentAsync(string AppointmentPatientName, DateTime AppointmentDate, DateTime AppointmentTime)
        {
            await services.addScheduleAppointment(AppointmentPatientName, AppointmentDate, AppointmentTime);

        }
    }
}
