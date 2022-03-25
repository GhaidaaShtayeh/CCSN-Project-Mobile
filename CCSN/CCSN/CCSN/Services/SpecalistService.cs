using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using CCSN.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace CCSN.Services
{
    public class SpecalistService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Specalist specalist)
        {
            var data = await firebaseClient.Child(nameof(Specalist)).PostAsync(JsonConvert.SerializeObject(specalist));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Specalist>> GetAll()
        {
            return (await firebaseClient
             .Child("Specalist") 
             .OnceAsync<Specalist>()).Select(item => new Specalist
             {
                 Email = item.Object.Email,
                 Name = item.Object.Name,
                 ID = item.Object.ID
             }).ToList();

           /* return (await firebaseClient.Child(nameof(Specalist)).OnceAsync<Specalist>()).Select(item => new Specalist
            {
                Email = item.Object.Email,
                Name = item.Object.Name,
                ID = item.Object.ID
            }).ToList();*/
        }

        public async Task<bool> Update(Specalist specalist)
        {
            await firebaseClient.Child(nameof(Specalist) + "/" + specalist.ID).PatchAsync(JsonConvert.SerializeObject(specalist));
            return true;
        }
    }
}
