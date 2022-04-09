using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using CCSN.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace CCSN.Services
{
    public class PatientService
    {
        static FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Patient patient)
        {
            var data = await firebaseClient.Child(nameof(Patient)).PostAsync(JsonConvert.SerializeObject(patient));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public static async Task<IEnumerable<Patient>> GetUserPatients()
        {
            var url = await firebaseClient
                     .Child($"Specalists/406707265/Patients").BuildUrlAsync();

            var result = await Helper.Get<List<Patient>>(url);
            return result ;
        }

        public async Task<bool> Update(Patient patient)
        {
            await firebaseClient.Child(nameof(Patient) + "/" + patient.ID).PatchAsync(JsonConvert.SerializeObject(patient));
            return true;
        }

        public async Task EditPatient(Patient patient, string ID)
        {
            await firebaseClient
          .Child($"Specalists/406707265/Patients/{ID}")
          .PatchAsync(JsonConvert.SerializeObject(patient));
        }

        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Patient) + "/" + id).DeleteAsync();
            return true;
        }
    }
}

