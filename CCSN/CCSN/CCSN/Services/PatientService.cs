using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using CCSN.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;

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
          .PatchAsync(patient);
        }

        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Patient) + "/" + id).DeleteAsync();
            return true;
        }
        public async Task<bool> IsPatientExists(string ID)
        {
            var Patient = (await firebaseClient.Child("/Specalists/406707265/Patients")

                .OnceAsync<Patient>()).Where(u => u.Object.ID == ID).FirstOrDefault();
            return (Patient != null);
        }

        public async Task<bool> AddPatients(string patientID, string patientAddress, string patientBirthday, string patientGender, string patientGenticsDiseses, string patientHeight, string patientMobileNo, string patientName, string patientWeight, List<Appoitment> appoitment)
        {
            if (await IsPatientExists(patientID) == false)
            {
            await firebaseClient.Child("/Specalists/406707265/Patients")
              .PostAsync(new Patient()
              {
                  ID = patientID,
                  PatientAddress = patientAddress,
                  PatientBirthday = patientBirthday,
                  PatientGender = patientGender,
                  PatientGenticesDiseses = patientGenticsDiseses,
                  PatientHeight = patientHeight,
                  PatientMobileNO = patientMobileNo,
                  PatientName = patientName,
                  PatientWeight = patientWeight,
                  Appointments = appoitment

              });
            return true;
             }
             else { return false; }
        }

    }
}

