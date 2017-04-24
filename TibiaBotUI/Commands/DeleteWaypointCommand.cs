using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediviaBotUI.Models;

namespace MediviaBotUI.Commands
{
    public class DeleteWaypointCommand
    {
        public ICommand Command;
        private readonly ObservableCollection<Waypoint> _waypoints;

        public DeleteWaypointCommand(ObservableCollection<Waypoint> waypoints)
        {
            Command = new RelayCommand<Waypoint>(_deleteWaypoint, _canDeleteWaypoint);
            _waypoints = waypoints;
        
        }

        private static bool _canDeleteWaypoint(Waypoint arg)
        {
            return arg != null;
        }

        private void _deleteWaypoint(Waypoint obj)
        {
            if (obj == null) return;
            foreach (Waypoint waypoint in _waypoints)
            {
                if (waypoint.Id >= obj.Id)
                    waypoint.Id = waypoint.Id - 1;
            }
            _waypoints.Remove(obj);
         
        }
    }
}
