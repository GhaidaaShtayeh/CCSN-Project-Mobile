using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCSN.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CCSN.ViewModels;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewFollowPage : ContentPage
    {
        AppintmentService FollowUpServices = new AppintmentService();
        public AddNewFollowPage()
        {
            InitializeComponent();

            BindingContext = new AddNewFollowModelView();
        }
        public void SaveFollowUpBtn(object sender, EventArgs e)
        {
            DisplayAlert("Success..!", "FollowUp added successfully", "Ok");
        }
    }
}