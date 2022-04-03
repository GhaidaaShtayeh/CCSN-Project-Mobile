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
            return result;
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
