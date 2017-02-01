using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TibiaBotUI.Models
{
    public class Waypoint : INotifyPropertyChanged
    {
     
        private int _id { get; set; }

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

        private WaypointType _type { get; set; }

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
        private string _label { get; set; }

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

        private WaypointDirection _waypointDirection { get; set; }

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
        private int _xWaypointRange;
       

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
        private int _yWaypointRange;
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
        private WaypointLocation _location { get; set; }

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

        private string _action { get; set; }

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


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
