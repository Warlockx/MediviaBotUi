using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TibiaBotUI.Commands;
using TibiaBotUI.Models;
using TibiaBotUI.Services;

namespace TibiaBotUI.ViewModels
{
    public class CavebotViewModel : INotifyPropertyChanged
    {
        private bool _cavebotEnabled;
        private Waypoint _currentWaypoint;
        private WaypointType _waypointType = WaypointType.Stand;
        private WaypointDirection _waypointDirection = WaypointDirection.Center;
        private WaypointLocation _waypointLocation = new WaypointLocation(0, 0, 0, WaypointDirection.Center);
        private ObservableCollection<Waypoint> _waypointList = new ObservableCollection<Waypoint>();
        private bool _editingAction;
        private int _xWaypointRange = 1;
        private int _yWaypointRange = 1;
        private string _actionCode;
        private readonly CavebotService _cavebotService;
        private int _walkOnFireThreshold;
        private int _walkOnPoisonThreshold;
        private int _walkOnEnergyThreshold;
        private int[] _walkableIds;

        public ICommand AddWaypoint { get; set; }
        public ICommand EditWaypointAction { get; set; }
        public ICommand DeleteWaypoint { get; set; }
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

        public WaypointType WaypointType
        {
            get { return _waypointType; }
            set
            {
                if (value == _waypointType) return;
                _waypointType = value;
                OnPropertyChanged();
            }
        }

        public WaypointDirection WaypointDirection
        {
            get { return _waypointDirection; }
            set
            {
                if (value == _waypointDirection) return;
                _waypointDirection = value;
                OnPropertyChanged();
            }
        }

        public WaypointLocation WaypointLocation
        {
            get { return _waypointLocation; }
            set
            {
                if (value == _waypointLocation) return;
                _waypointLocation = value;
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

        public int XWaypointRange
        {
            get { return _xWaypointRange; }
            set
            {
                if (value == _xWaypointRange) return;
                _xWaypointRange = value;
                OnPropertyChanged();
            }
        }

        public int YWaypointRange
        {
            get { return _yWaypointRange; }
            set
            {
                if (value == _yWaypointRange) return;
                _yWaypointRange = value;
                OnPropertyChanged();
            }
        }

        public string ActionCode
        {
            get { return _actionCode; }
            set
            {
                if(value == _actionCode) return;
                _actionCode = value;
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
        private bool _canAddWaypoint(object arg)
        {
            return _waypointLocation != null;
        }

        private void _addWaypoint(object obj)
        {
            int waypointIndex = WaypointList.Count;
            if (obj != null)
            {
                Waypoint currentWaypoint = (Waypoint)obj;
                waypointIndex = currentWaypoint.Id+1;
                foreach (Waypoint waypoint in WaypointList)
                {
                    if (waypoint.Id >= waypointIndex)
                        waypoint.Id = waypoint.Id + 1;
                }
                WaypointList.Insert(waypointIndex,new Waypoint(waypointIndex, WaypointType, XWaypointRange, YWaypointRange, "",
                     new WaypointLocation(WaypointLocation, WaypointDirection), ActionCode));
            }
            else
            {
                WaypointList.Add(new Waypoint(waypointIndex, WaypointType, XWaypointRange, YWaypointRange, "",
                    new WaypointLocation(WaypointLocation,WaypointDirection), ActionCode));
            }
        }

        private bool _canEditWaypointAction(object arg)
        {
            Waypoint waypoint = (Waypoint)arg;
            return waypoint?.Type == WaypointType.Action;
        }

        private void _editWaypointAction(object obj)
        {
            EditingAction = true;
        }
        #endregion


        public CavebotViewModel()
        {
            AddWaypoint = new RelayCommand(_addWaypoint, _canAddWaypoint);
            EditWaypointAction = new RelayCommand(_editWaypointAction, _canEditWaypointAction);
            DeleteWaypoint = new RelayCommand(_deleteWaypoint,_canDeleteWaypoint);
            _cavebotService = new CavebotService(this);
          
        }

        private bool _canDeleteWaypoint(object arg)
        {
            return arg != null;
        }

        private void _deleteWaypoint(object obj)
        {
            Waypoint waypoint = (Waypoint) obj;
            if (waypoint == null) return;
            foreach (Waypoint _waypoint in WaypointList)
            {
                if (_waypoint.Id >= waypoint.Id)
                    _waypoint.Id = _waypoint.Id - 1;
            }
            WaypointList.Remove(waypoint);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
