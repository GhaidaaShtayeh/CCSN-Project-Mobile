using Firebase;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using CCSN.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace CCSN.Services
{
    public class FollowUpService
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ccsn-fed2d-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(FollowUp followUp)
        {
            var data = await firebaseClient.Child(nameof(FollowUp)).PostAsync(JsonConvert.SerializeObject(followUp));
            if (string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<FollowUp>> GetAll()
        {
            return (await firebaseClient.Child(nameof(FollowUp)).OnceAsync<FollowUp>()).Select(item => new FollowUp
            {
                FollowUpNumber = item.Object.FollowUpNumber,
                FollowUpDate = item.Object.FollowUpDate,
                FollowUpTools = item.Object.FollowUpTools,
                FollowUpGoals = item.Object.FollowUpGoals,
                FollowUpAddNote = item.Object.FollowUpAddNote
            }).ToList();
        }

        public async Task<bool> Update(FollowUp followUp)
        {
            await firebaseClient.Child(nameof(FollowUp) + "/" + followUp.FollowUpNumber).PatchAsync(JsonConvert.SerializeObject(followUp));
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(FollowUp) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
