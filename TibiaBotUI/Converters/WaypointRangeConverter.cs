using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TibiaBotUI.Converters
{
    public class WaypointRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] range = value.ToString().Split('x');
            int x = int.Parse(range[0]);
            int y = int.Parse(range[1]);

            return new object[] {x, y};
        }
    }
}
