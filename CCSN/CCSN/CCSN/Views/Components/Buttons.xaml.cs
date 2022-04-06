using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views.Components
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Buttons 
    {
        public Buttons()
        {
            InitializeComponent();
        }
    }
}