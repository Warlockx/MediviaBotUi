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
        public ICommand EditWaypointAction { get;  }
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
                _currentWaypoint = value;
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
        #region commands
        private static bool _canEditWaypointAction(Waypoint arg)
        {
            return arg?.Type == WaypointType.Action;
        }

        private void _editWaypointAction(Waypoint obj)
        {
            EditingAction = true;
        }

        

        private static bool _canDeleteWaypoint(Waypoint arg)
        {
            return arg != null;
        }

        private void _deleteWaypoint(Waypoint obj)
        {
            if (obj == null) return;
            foreach (Waypoint waypoint in WaypointList)
            {
                if (waypoint.Id >= obj.Id)
                    waypoint.Id = waypoint.Id - 1;
            }
            WaypointList.Remove(obj);
        }
        #endregion


        public CavebotViewModel()
        {
            _currentWaypoint = new Waypoint(0,WaypointType.Stand, 1,1,string.Empty, new WaypointLocation(0, 0, 0, WaypointDirection.Center),string.Empty);
            AddWaypoint = new AddWaypointCommand(_currentWaypoint,_waypointList).Command;
         
            EditWaypointAction = new RelayCommand<Waypoint>(_editWaypointAction, _canEditWaypointAction);
            DeleteWaypoint = new RelayCommand<Waypoint>(_deleteWaypoint,_canDeleteWaypoint);
            _cavebotService = new CavebotService(this);
          
        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
