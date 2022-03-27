using CCSN.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSN.Services
{
    public class AppintmentService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Appoitment appointment)
        {
            var data = await firebaseClient.Child(nameof(Appoitment)).PostAsync(JsonConvert.SerializeObject(appointment));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Appoitment>> GetAll()
        {
            var req = await firebaseClient.Child("Specalists/406707265/Patients/0/Appointments").OnceAsync<Appoitment>();

            return (await firebaseClient.Child("Specalists/406707265/Patients/0/Appointments").OnceAsync<Appoitment>()).Select(item => new Appoitment
            {
                AppointmentNumber = item.Object.AppointmentNumber,
                AppointmentPatientName = item.Object.AppointmentPatientName,
                AppointmentDate = item.Object.AppointmentDate,
                AppointmentTime = item.Object.AppointmentTime,
                FollowUpDate = item.Object.FollowUpDate,
                FollowUpTools = item.Object.FollowUpTools,
                FollowUpGoals = item.Object.FollowUpGoals,
                FollowUpAddNote = item.Object.FollowUpAddNote,
            }).ToList();
        }

        public async Task<bool> Update(Appoitment appointment)
        {
            await firebaseClient.Child(nameof(Appoitment) + "/" + appointment.AppointmentNumber).PatchAsync(JsonConvert.SerializeObject(appointment));
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Appoitment) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
