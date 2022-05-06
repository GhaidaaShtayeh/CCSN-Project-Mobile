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
using CCSN.Common;

namespace CCSN.Services
{
    public class PatientService
    {
        static FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");

        public static async Task<IEnumerable<Patient>> GetUserPatients()
        {
            var url = await firebaseClient
                     .Child($"Specalists/{PreferencesConfig.Id}/Patients").BuildUrlAsync();
            var result = await Helper.Get<List<Patient>>(url);
            return result;

        }

        public async Task EditPatient(Patient patient, string ID)
        {
            await firebaseClient
          .Child($"Specalists/{PreferencesConfig.Id}/Patients/{ID}")
          .PatchAsync(patient);
        }



        public async Task DeletePatient(string ID)
        {
            await firebaseClient
           .Child($"Specalists/{PreferencesConfig.Id}/Patients/{ID}")
           .DeleteAsync();
        }

        public async Task<bool> IsPatientExists(string ID)
        {
            var result = (await GetUserPatients()).ToList();

            return (result.Any(x => x.ID == ID));
        }

        public async Task<bool> AddPatients(string patientID, string patientAddress, string patientBirthday, string patientGender, string patientGenticsDiseses, string patientHeight, string patientMobileNo, string patientName, string patientWeight, List<Appoitment> appoitment)
        {
            if (await IsPatientExists(patientID) == false)
            {
                await firebaseClient.Child($"/Specalists/{PreferencesConfig.Id}/Patients/{patientID}")
                  .PutAsync(new Patient()
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
                      //Appointments = appoitment

                  });
                return true;
            }
            else { return false; }
        }



    }
}

