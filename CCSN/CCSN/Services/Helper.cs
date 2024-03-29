﻿using CCSN.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCSN.Services
{
    public class Helper
    {
        public static async Task<TEntity> Get<TEntity>(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            if (json.Contains("null,"))
                json = json.Replace("null,", "");
            else if(json.Contains(",null"))
                json = json.Replace(",null", "");


            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            return JsonConvert.DeserializeObject<TEntity>(json);
            // }
            // else
            // {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new Views.EmptyViewPage());

            // }
        }
    }
}
