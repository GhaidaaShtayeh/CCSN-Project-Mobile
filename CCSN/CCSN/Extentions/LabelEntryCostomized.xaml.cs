using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCSN.Extentions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelEntryCostomized : ContentView
    {
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(LabelEntryCostomized));

        public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(LabelEntryCostomized), default, BindingMode.TwoWay);
        
        public string LabelText { get => (string)GetValue(LabelTextProperty); set => SetValue(LabelTextProperty, value); }
        public string EntryText { get => (string)GetValue(EntryTextProperty); set => SetValue(EntryTextProperty, value); }

        public LabelEntryCostomized()
        {
            InitializeComponent();
            label.Text = LabelText;
            entry.Text = EntryText;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(LabelText))
                label.Text = LabelText;
            else if(propertyName == nameof(EntryText))
                entry.Text = EntryText;
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntryText = e.NewTextValue;
        }
    }
}