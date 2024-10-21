using Energy;
using EnergyUI.ViewModel;
using EnergyUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EnergyUI
{
    public class DataViewModel : INotifyPropertyChanged
    {
        public DataViewModel() {
            SetControlVisibility = new Command(ControlVisibility);
            DisableCounterCommand = new Command(DisableCounter);
            EnableCounterCommand = new Command(EnableCounter);
        }
        private string _visibleControl = "Counters";

        public string VisibleControl
        {
            get => _visibleControl;
            set
            {
                if (_visibleControl != value)
                {
                    _visibleControl = value;
                    OnPropertyChanged("VisibleControl");
                }
            }
        }

        private ObservableCollection<User> _users;
        private ObservableCollection<Counter> _counters;
        private ObservableCollection<Report> _reports;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged("Users");
                }
            }
        }

        public ObservableCollection<Counter> Counters
        {
            get => _counters;
            set
            {
                if (_counters != value)
                {
                    _counters = value;
                    OnPropertyChanged("Counters");
                }
            }
        }

        public ObservableCollection<Report> Reports
        {
            get => _reports;
            set
            {
                if (_reports != value)
                {
                    _reports = value;
                    OnPropertyChanged("Reports");
                }
            }
        }

        public ICommand SetControlVisibility {  get; set; }

        public void ControlVisibility(object args)
        {
            VisibleControl = args.ToString();
        }

        public ICommand DisableCounterCommand { get; set; }

        public void DisableCounter(object args)
        {
            if (SelectedCounter != null && args is MeterStatus newStatus)
            {
                SelectedCounter.Status = newStatus;
            }
        }

        private CounterViewModel _selectedCounter;

        public CounterViewModel SelectedCounter
        {
            get
            {
                return _selectedCounter;
            }
            set
            {
                _selectedCounter = value;
                OnPropertyChanged("SelectedCounter");
            }
        }

        public ICommand EnableCounterCommand { get; set; }

        public void EnableCounter(object args)
        {
            if (SelectedCounter != null && SelectedCounter.Status == MeterStatus.Disabled)
            {
                SelectedCounter.Status = MeterStatus.Enabled;
            }
        }

        // Подія для відстеження змін властивостей
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для виклику події PropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveData()
        {
            var dataModel = new DataModel()
            {
                Users = _users,
                Counters = _counters,
                Reports = _reports
            };
            dataModel.Save();
        }

        public static DataViewModel LoadData()
        {
            var dataModel = DataModel.Load();
            return new DataViewModel
            {
                Users = new ObservableCollection<User>(dataModel.Users),
                Counters = new ObservableCollection<Counter>(dataModel.Counters),
                Reports = new ObservableCollection<Report>(dataModel.Reports)
            };
        }
    }
}
