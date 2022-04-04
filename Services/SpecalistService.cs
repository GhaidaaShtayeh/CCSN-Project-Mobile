using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Models;
using Firebase.Database;
using Newtonsoft.Json;

namespace CCSN.Services
{
    public class SpecalistService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Specalist specalist)
        {

            var data = await firebaseClient.Child("Specalists").PostAsync(JsonConvert.SerializeObject(specalist));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Specalist>> GetAll()
        {
            return (await firebaseClient
             .Child("Specalists")
             .OnceAsync<Specalist>()).Select(item => new Specalist
             {
                 Email = item.Object.Email,
                 Name = item.Object.Name,
                 ID = item.Object.ID,
                 Patients = item.Object.Patients.ToList()
             }).ToList();

        }

        public async Task<bool> Update(Specalist specalist)
        {
            await firebaseClient.Child("Specalists" + "/" + specalist.ID).PatchAsync(JsonConvert.SerializeObject(specalist));
            return true;
        }

        public async Task<bool> LoginUser(string userID, string userpassword)
        {
            var user = (await firebaseClient.Child("Specalists")
                .OnceAsync<Specalist>()).Where(u => u.Object.ID == userID)
                .Where(u => u.Object.password == userpassword).FirstOrDefault();
            return (user != null);
        }
    }
}
