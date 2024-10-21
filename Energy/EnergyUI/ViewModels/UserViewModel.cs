using EnergyUI.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EnergyUI.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private string _counterNumber;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string CounterNumber
        {
            get => _counterNumber;
            set
            {
                if (_counterNumber != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(CounterNumber));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
