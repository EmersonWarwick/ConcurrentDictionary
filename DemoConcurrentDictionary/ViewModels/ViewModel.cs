using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoConcurrentDictionary
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private string _StringFromDictionary = "0";
        public string StringFromDictionary
        {
            get => _StringFromDictionary;
            set
            {
                _StringFromDictionary = value;
                OnPropertyChanged();
            }
        }

        private string _StringFromSummary = "0";
        public string StringFromSummary
        {
            get => _StringFromSummary;
            set
            {
                _StringFromSummary = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName= null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
