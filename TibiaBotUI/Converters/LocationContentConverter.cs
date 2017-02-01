using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TibiaBotUI.Models;

namespace TibiaBotUI.Converters
{
    public class LocationContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WaypointLocation waypointLocation = (WaypointLocation) value;
            return waypointLocation == null ? null : $"{waypointLocation.X},{waypointLocation.Y},{waypointLocation.Z}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string waypointLocation = (string) value;
            string[] waypointStringSplit = waypointLocation?.Split(',');
            return waypointLocation == null
                ? null
                : new WaypointLocation(int.Parse(waypointStringSplit[0]), int.Parse(waypointStringSplit[1]), int.Parse(waypointStringSplit[2]), WaypointDirection.Center);
        }
    }
}
