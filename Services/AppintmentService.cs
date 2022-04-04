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
        // get scheual appointment 
        public ObservableCollection<Appoitment> getScheduleAppointment()
        {
            var ScheduleData = firebaseClient
             .Child("Appointments")
             .AsObservable<Appoitment>()
             .AsObservableCollection();

            return ScheduleData;
        }
        // add schedule appointment 
        public async Task addScheduleAppointment(string patientname, DateTime appointmentDate, DateTime appointmentTime)
        {
            Appoitment A = new Appoitment()
            {
                AppointmentPatientName = patientname,
                AppointmentDate = appointmentDate,
                AppointmentTime = appointmentTime

            };
            await firebaseClient
                .Child("Appointments")
                .PostAsync(A);
        }
        // get user appointment 
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

        public static async Task EditAppointment(string UserID, Appoitment appoitment)
        {
            await firebaseClient
          .Child($"Specalists/{UserID}/Patients/0/Appointments")
          .PatchAsync(appoitment);
        }

        public static async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Appoitment) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
