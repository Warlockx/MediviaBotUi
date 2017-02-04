using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TibiaBotUI.Models
{
    public class WaypointLocation : INotifyPropertyChanged
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                if (value == _x) return;
                _x = value;
                OnPropertyChanged();
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                if (value == _y) return;
                _y = value;
                OnPropertyChanged();
            }
        }

        private int _z;
        public int Z
        {
            get { return _z; }
            set
            {
                if (value == _z) return;
                _z = value;
                OnPropertyChanged();
            }
        }

        public WaypointLocation(int x,int y, int z, WaypointDirection direction)
        {
            Tuple<int, int> directionOffset = new Tuple<int, int>(0, 0); //Horizontal Axis, Vertical Axis
            switch (direction)
            {
                case WaypointDirection.NorthWest:
                    directionOffset = new Tuple<int, int>(-1, -1);
                    break;
                case WaypointDirection.North:
                    directionOffset = new Tuple<int, int>(0, -1);
                    break;
                case WaypointDirection.NorthEast:
                    directionOffset = new Tuple<int, int>(+1, -1);
                    break;
                case WaypointDirection.East:
                    directionOffset = new Tuple<int, int>(+1, 0);
                    break;
                case WaypointDirection.SouthEast:
                    directionOffset = new Tuple<int, int>(+1, +1);
                    break;
                case WaypointDirection.South:
                    directionOffset = new Tuple<int, int>(0, +1);
                    break;
                case WaypointDirection.SouthWest:
                    directionOffset = new Tuple<int, int>(-1, +1);
                    break;
                case WaypointDirection.West:
                    directionOffset = new Tuple<int, int>(-1, 0);
                    break;
                case WaypointDirection.Center:
                    directionOffset = new Tuple<int, int>(0, 0);
                    break;
            }
            X = x + directionOffset.Item1;
            Y = y + directionOffset.Item2;
            Z = z;
        }

        public WaypointLocation(WaypointLocation location, WaypointDirection direction)
        {
            Tuple<int, int> directionOffset = new Tuple<int, int>(0, 0); //Horizontal Axis, Vertical Axis
            switch (direction)
            {
                case WaypointDirection.NorthWest:
                    directionOffset = new Tuple<int, int>(-1, -1);
                    break;
                case WaypointDirection.North:
                    directionOffset = new Tuple<int, int>(0, -1);
                    break;
                case WaypointDirection.NorthEast:
                    directionOffset = new Tuple<int, int>(+1, -1);
                    break;
                case WaypointDirection.East:
                    directionOffset = new Tuple<int, int>(+1, 0);
                    break;
                case WaypointDirection.SouthEast:
                    directionOffset = new Tuple<int, int>(+1, +1);
                    break;
                case WaypointDirection.South:
                    directionOffset = new Tuple<int, int>(0, +1);
                    break;
                case WaypointDirection.SouthWest:
                    directionOffset = new Tuple<int, int>(-1, +1);
                    break;
                case WaypointDirection.West:
                    directionOffset = new Tuple<int, int>(-1, 0);
                    break;
                case WaypointDirection.Center:
                    directionOffset = new Tuple<int, int>(0, 0);
                    break;
            }
            X = location.X + directionOffset.Item1;
            Y = location.Y + directionOffset.Item2;
            Z = location.Z;
        }



        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
