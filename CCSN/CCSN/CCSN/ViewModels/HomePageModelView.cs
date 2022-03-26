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
        public SpecalistService specalistService;
        public List<Specalist> specs;
        public HomePageModelView()
        {
            specs = new List<Specalist>();
            specalistService = new SpecalistService();
            Button_ClickedAsync();
        }


        async private void Button_ClickedAsync()
        {
            specs = await specalistService.GetAll();
            specs.ForEach(spec => Console.WriteLine(spec.Name));
        }
    }
}
