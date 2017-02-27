using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MediviaBotUI.Models
{
    public class Waypoint : INotifyPropertyChanged
    {

        private int _id;
        private WaypointType _type;
        private string _label;
        private WaypointDirection _waypointDirection;
        private int _xWaypointRange;
        private int _yWaypointRange;
        private WaypointLocation _location;
        private string _action;

        public int Id
        {
            get { return _id; }
            set
            {
                if(value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public WaypointType Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Label
        {
            get { return _label; }
            set
            {
                if (value == _label) return;
                _label = value;
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

        public WaypointLocation Location
        {
            get { return _location; }
            set
            {
                if (value == _location) return;
                _location = value;
                OnPropertyChanged();
            }
        }

        public string Action
        {
            get { return _action; }
            set
            {
                if (value == _action) return;
                _action = value;
                OnPropertyChanged();
            }
        }



        public Waypoint(int id, WaypointType type,int xWaypointRange, int yWaypointRange , string label, WaypointLocation location, string action)
        {
            Id = id;
            Type = type;
            Label = label;
            Location = location;
            Action = action;
            XWaypointRange = xWaypointRange;
            YWaypointRange = yWaypointRange;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
