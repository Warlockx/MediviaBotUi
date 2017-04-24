using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MediviaBotUI.Commands;
using MediviaBotUI.Models;
using MediviaBotUI.Services;

namespace MediviaBotUI.ViewModels
{
    public class CavebotViewModel : INotifyPropertyChanged
    {
        private bool _cavebotEnabled;
        private Waypoint _currentWaypoint;
        private static ObservableCollection<Waypoint> _waypointList = new ObservableCollection<Waypoint>();
        private readonly CavebotService _cavebotService;
        private bool _editingAction;
        private int _walkOnFireThreshold;
        private int _walkOnPoisonThreshold;
        private int _walkOnEnergyThreshold;
        //needs a converter
        private int[] _walkableIds;

        public ICommand AddWaypoint { get; }
        public ICommand EditWaypointAction { get; }
        public ICommand DeleteWaypoint { get;  }
        public bool CavebotEnabled
        {
            get { return _cavebotEnabled; }
            set
            {
                if (value == _cavebotEnabled) return;
                _cavebotEnabled = value;
                if(value)
                    _cavebotService.Start();
                OnPropertyChanged();
            }
        }
        public bool EditingAction
        {
            get { return _editingAction; }
            set
            {
                if (value == _editingAction) return;
                _editingAction = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Waypoint> WaypointList
        {
            get { return _waypointList; }
            set
            {
                if (value == _waypointList) return;
                _waypointList = value;
                OnPropertyChanged();
            }
        }
        public Waypoint CurrentWaypoint
        {
            get { return _currentWaypoint; }
            set
            {
                if(value == _currentWaypoint) return;
                _currentWaypoint = value ??
                                   new Waypoint().Default();
                OnPropertyChanged();
            }
        }
        public int WalkOnFireThreshold
        {
            get { return _walkOnFireThreshold; }
            set
            {
                if (value == _walkOnFireThreshold) return;
                _walkOnFireThreshold = value;
                OnPropertyChanged();
            }
        }
        public int WalkOnPoisonThreshold
        {
            get { return _walkOnFireThreshold; }
            set
            {
                if (value == _walkOnPoisonThreshold) return;
                _walkOnPoisonThreshold = value;
                OnPropertyChanged();
            }
        }
        public int WalkOnEnergyThreshold
        {
            get { return _walkOnEnergyThreshold; }
            set
            {
                if (value == _walkOnEnergyThreshold) return;
                _walkOnEnergyThreshold = value;
                OnPropertyChanged();
            }
        }
        public int[] WalkableIds
        {
            get { return _walkableIds; }
            set
            {
                if(value == _walkableIds) return;
                _walkableIds = value;
                OnPropertyChanged();
            }
        }

        
        public CavebotViewModel()
        {
            _currentWaypoint = new Waypoint().Default();
            AddWaypoint = new AddWaypointCommand(CurrentWaypoint, WaypointList).Command;
            EditWaypointAction = new RelayCommand<Waypoint>(w => { EditingAction = true; }, w => w?.Type == WaypointType.Action);
            
            DeleteWaypoint = new DeleteWaypointCommand(WaypointList).Command;
            _cavebotService = new CavebotService(this);
          
        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
