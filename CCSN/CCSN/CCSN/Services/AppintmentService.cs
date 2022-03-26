using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCSN.Services
{
    public class AppintmentService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Appointment appointment)
        {
            var data = await firebaseClient.Child(nameof(Appointment)).PostAsync(JsonConvert.SerializeObject(appointment));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Appointment)).OnceAsync<Appointment>()).Select(item => new Appointment
            {
                AppointmentNumber = item.Object.AppointmentNumber,
                AppointmentPatientName = item.Object.AppointmentPatientName,
                AppointmentDate = item.Object.AppointmentDate,
                AppointmentTime = item.Object.AppointmentTime
            }).ToList();
        }

        public async Task<bool> Update(Appointment appointment)
        {
            await firebaseClient.Child(nameof(Appointment) + "/" + appointment.AppointmentNumber).PatchAsync(JsonConvert.SerializeObject(appointment));
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Appointment) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
