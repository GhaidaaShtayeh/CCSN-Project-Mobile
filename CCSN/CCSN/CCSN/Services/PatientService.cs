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
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Patient patient)
        {
            var data = await firebaseClient.Child(nameof(Patient)).PostAsync(JsonConvert.SerializeObject(patient));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Patient>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Patient)).OnceAsync<Patient>()).Select(item => new Patient
            {
                ID = item.Object.ID,
                PatientName = item.Object.PatientName,
                PatientAddress = item.Object.PatientAddress,
                PatientWeight = item.Object.PatientWeight,
                PatientHeight = item.Object.PatientHeight,
                PatientBirthday = item.Object.PatientBirthday,
                PatientMobileNO = item.Object.PatientMobileNO,
                PatientGenticesDiseses = item.Object.PatientGenticesDiseses,


            }).ToList();
        }

        public async Task<bool> Update(Patient patient)
        {
            await firebaseClient.Child(nameof(Patient) + "/" + patient.ID).PatchAsync(JsonConvert.SerializeObject(patient));
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Patient) + "/" + id).DeleteAsync();
            return true;
        }
    }
}

