using CCSN.Common;
using CCSN.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCSN.Services
{
    public class AppintmentService
    {
        static FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");



        public static async Task<IEnumerable<Appoitment>> GetUserAppointmentsByDate(DateTime? dateTime, string str)
        {
            var Patients = await PatientService.GetUserPatients();

            if (Patients == null)
                return new List<Appoitment>();
            else
            {
                List<Appoitment> appointments = new List<Appoitment>();
                foreach (var patient in Patients)
                {
                    if (patient.Appointments != null)
                        appointments.AddRange(patient.Appointments.Values);
                }

                if (appointments == null && str == "all")
                    return new List<Appoitment>();
                else if (appointments != null && str == "up")
                    return (appointments.Where(o => o.AppointmentDate.Date.Date > DateTime.Now.Date));
                else if (dateTime.HasValue)
                    return (appointments.Where(o => o.AppointmentDate.Date.Date == dateTime.Value.Date));
                else
                    return appointments;
            }

        }

        public static async Task<bool> IsAppointmentExist(DateTime date, TimeSpan time)
        {
            var result = (await GetUserAppointmentsByDate(null, "up")).ToList();

            return (result.Any(x => x.AppointmentDate == date && x.AppointmentTime == time));
        }
        public static async Task EditFollowup(Appoitment appoitment, string PatientID, string FollowID)
        {
            await firebaseClient
          .Child($"Specalists/{PreferencesConfig.Id}/Patients/{PatientID}/Appointments/{FollowID}")
          .PatchAsync(appoitment);
        }

        public async Task DeleteFollowup(string PatientID, string FollowID)
        {
            await firebaseClient
          .Child($"Specalists/{PreferencesConfig.Id}/Patients/{PatientID}/Appointments/{FollowID}")
           .DeleteAsync();
        }


        // add schedule Appointment 


        public static async Task<bool> addScheduleAppointment(string patientId, string patientname, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            if (await IsAppointmentExist(appointmentDate, appointmentTime) == false)
            {
                Appoitment A = new Appoitment()
                {
                    AppointmentPatientName = patientname,
                    AppointmentDate = appointmentDate,
                    AppointmentTime = appointmentTime,
                    PatientID = patientId,
                    ID = Common.Helper.GenerateKey(8)

                };
                await firebaseClient
                    .Child($"Specalists/{PreferencesConfig.Id}/Patients/{patientId}/Appointments/{A.ID}")
                    .PutAsync(A);
                return true;
            }
            else
            {
                return false;
            }

        }

        //add follow up 
        public ObservableCollection<Appoitment> GetFollowUp(string PatientID)
        {
            var FollowUp = firebaseClient
             .Child($"Specalists/{PreferencesConfig.Id}/Patients/{PatientID}/Appointments")
             .AsObservable<Appoitment>()
             .AsObservableCollection();

            return FollowUp;
        }


    }
}