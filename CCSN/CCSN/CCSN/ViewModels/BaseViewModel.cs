using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CCSN.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _IsLoading;
        private string _Message;

        public bool IsLoading { get => _IsLoading; set => SetProperty(ref _IsLoading, value, nameof(IsLoading)); }
        public string Message { get => _Message; set => SetProperty(ref _Message, value, nameof(Message)); }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                RaizePropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        public void RaizePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
