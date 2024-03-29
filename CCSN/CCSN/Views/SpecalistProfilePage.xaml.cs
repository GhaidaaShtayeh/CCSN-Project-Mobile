﻿using CCSN.Models;
using CCSN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecalistProfilePage : ContentPage
    {
        public SpecalistProfilePage()
        {
            InitializeComponent();
            BindingContext = new SpcalistProfilePageModelView(Navigation);
        }
        public SpecalistProfilePage(Specalist specalist)
        {
            InitializeComponent();
            BindingContext = new SpcalistProfilePageModelView(specalist);
        }

    }
}
