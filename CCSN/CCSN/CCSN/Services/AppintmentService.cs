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
        public static async Task<bool> Save(Appoitment appointment)
        {
            var data = await firebaseClient.Child(nameof(Appoitment)).PostAsync(JsonConvert.SerializeObject(appointment));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public static async Task<IEnumerable<Appoitment>> GetUserAppointments()
        {
            var url = (await firebaseClient
                     .Child($"Specalists/406707265/Patients/0/Appointments").BuildUrlAsync());

            var result = await Helper.Get<List<Appoitment>>(url);
            return result.Where(o => o.AppointmentDate.Date == DateTime.Now.Date);
        }

        public static async Task<IEnumerable<Appoitment>> GetUserAllAppointments()
        {
            var url = (await firebaseClient
                     .Child($"Specalists/406707265/Patients/0/Appointments").BuildUrlAsync());

            var result = await Helper.Get<List<Appoitment>>(url);
            return result;
        }

        public static async Task<IEnumerable<Appoitment>> GetUserTAppointments()
        {
            var url = (await firebaseClient
                     .Child($"Specalists/406707265/Patients/0/Appointments").BuildUrlAsync());

            var result = await Helper.Get<List<Appoitment>>(url);
            return result.Where(o => o.AppointmentDate.Date == DateTime.Today.AddDays(1).Date);
        }

        public static async Task EditAppointment(Appoitment appoitment)
        {
            await firebaseClient
          .Child($"Specalists/406707265/Patients/0/Appointments")
          .PatchAsync(appoitment);
        }

        public static async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Appoitment) + "/" + id).DeleteAsync();
            return true;
        }
        // add schedule Appointment 
        public ObservableCollection<Appoitment> getScheduleAppointment()
        {
            var ScheduleData = firebaseClient
             .Child("$Specalists / 406707265 / Patients / 0 / Appointments")
             .AsObservable<Appoitment>()
             .AsObservableCollection();

            return ScheduleData;
        }
        public async Task addScheduleAppointment(string patientname, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            Appoitment A = new Appoitment()
            {
                AppointmentPatientName = patientname,
                AppointmentDate = appointmentDate,
                AppointmentTime = appointmentTime

            };
            await firebaseClient
                .Child($"Specalists/406707265/Patients/0/Appointments")
                .PostAsync(A);
        }

        //add follow up 
        public ObservableCollection<Appoitment> getFollowUp()
        {
            var FollowUp = firebaseClient
             .Child("$Specalists / 406707265 / Patients / 0 / Appointments")
             .AsObservable<Appoitment>()
             .AsObservableCollection();

            return FollowUp;
        }
        public async Task addFollowUp(string followUpDate, string followUpTools, string followUpGoals, string followUpAddNote)
        {
            Appoitment A = new Appoitment()
            {
                FollowUpDate = followUpDate,
                FollowUpTools = followUpTools,
                FollowUpGoals = followUpGoals,
                FollowUpAddNote = followUpAddNote

            };
            await firebaseClient
                .Child($"Specalists/406707265/Patients/0/Appointments")
                .PostAsync(A);
        }
    }
}
