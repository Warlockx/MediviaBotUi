using System;
using System.Globalization;
using System.Windows.Data;

namespace MediviaBotUI.Converters
{
    public class HealTriggerRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] range = value.ToString().Replace("%","").Split('~');
            int x = int.Parse(range[0]);
            int y = int.Parse(range[1]);

            if (x <= y) return new object[] {x, y};


            int localx = x;
            int localy = y;
            y = localx;
            x = localy;

            return new object[] { x, y };
        }
    }
}
