using CCSN.Models;
using CCSN.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CCSN.ViewModels
{
    public class HomePageModelView : BindableObject
    {
        public AppintmentService AppointmentService;
        public List<Appoitment> Apo;
        public HomePageModelView()
        {
            Apo = new List<Appoitment>();
            AppointmentService = new AppintmentService();
            Button_ClickedAsync();
        }


        async private void Button_ClickedAsync()
        {
            Apo = await AppointmentService.GetAll();
            Apo.ForEach(Apo => Console.WriteLine(Apo.AppointmentPatientName));
        }
    }
}
