using System.ComponentModel;
using System.Runtime.CompilerServices;
using Energy;

namespace EnergyUI.ViewModel
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private int _count;
        private MeterStatus _status;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }

        public MeterStatus Status
        {
            get => Status1;
            set
            {
                if (Status1 != value)
                {
                    Status1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public MeterStatus Status1 { get => _status; set => _status = value; }

        // Event to handle property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
