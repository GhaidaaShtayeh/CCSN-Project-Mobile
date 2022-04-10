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

            public DateTime AppointmentDate { get; set; }//Calender 
            public string AppointmentPatientName { get; set; } //picker 

            private AppintmentService _Services;
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
          
          // calender 
        private ObservableCollection<XamForms.Controls.SpecialDate> _calender;
        public ObservableCollection<XamForms.Controls.SpecialDate> Calender
        {
            get
            {
                return _calender;
            }
            set
            {
                _calender = value;
                OnPropertyChanged(nameof(Calender));
            }
        }

        public Command DateChosen
        {
            get
            {
                return new Command((obj) =>
                {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);
                });
            }
        }
            public ScheduleAppointmentPageModelView()
            {
            _Services = new AppintmentService();
                Schedules = _Services.getScheduleAppointment();
                AddScheduleCommand = new Command(async () => await addScheduleAppointmentAsync(AppointmentPatientName, AppointmentDate.Date, AppointmentTime));

            }
            public async Task addScheduleAppointmentAsync(string AppointmentPatientName, DateTime AppointmentDate, TimeSpan AppointmentTime)
            {
                await _Services.addScheduleAppointment(AppointmentPatientName, AppointmentDate, AppointmentTime);

            }
            // view appointment 
            public void AllAppointment()
        {
            services = new AppintmentService();
            Schedules = services.getScheduleAppointment();
        }

        }
    }

