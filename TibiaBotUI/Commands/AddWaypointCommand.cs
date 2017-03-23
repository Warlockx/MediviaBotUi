using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediviaBotUI.Models;
using MediviaBotUI.ViewModels;

namespace MediviaBotUI.Commands
{
    public class AddWaypointCommand
    {
        public ICommand Command;
        private ObservableCollection<Waypoint> _waypoints;
        private readonly Waypoint _currentWaypoint;
        public AddWaypointCommand(Waypoint currentWaypoint, ObservableCollection<Waypoint> waypoints)
        {
            Command = new RelayCommand<Waypoint>(_addToCollection,_canAddToCollection);
            _currentWaypoint = currentWaypoint;
            _waypoints = waypoints;
        }

        private bool _canAddToCollection(object arg)
        {
            return _currentWaypoint.Location != null;
        }

        private void _addToCollection(Waypoint obj)
        {
            int waypointIndex = _waypoints.Count;
            if (obj != null)
            {
                waypointIndex = obj.Id + 1;
                _waypoints.Where(w => w.Id >= waypointIndex).ToList().ForEach(w => w.Id++);

                _waypoints.Insert(waypointIndex,
                    new Waypoint(waypointIndex, _currentWaypoint.Type, _currentWaypoint.XWaypointRange,
                        _currentWaypoint.YWaypointRange, "",
                        new WaypointLocation(_currentWaypoint.Location, _currentWaypoint.WaypointDirection),
                        _currentWaypoint.Action));
            }
            else
            {
                _waypoints.Add(new Waypoint(waypointIndex, _currentWaypoint.Type, _currentWaypoint.XWaypointRange,
                    _currentWaypoint.YWaypointRange, "",
                    new WaypointLocation(_currentWaypoint.Location, _currentWaypoint.WaypointDirection),
                    _currentWaypoint.Action));
            }
        }
    }
}
