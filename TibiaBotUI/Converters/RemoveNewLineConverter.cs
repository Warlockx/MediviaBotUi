using System;
using System.Windows.Data;

namespace MediviaBotUI.Converters
{
    public class RemoveNewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string) value;
            return str?.Replace(Environment.NewLine, " ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("Method not implemented");
        }
    }
}
