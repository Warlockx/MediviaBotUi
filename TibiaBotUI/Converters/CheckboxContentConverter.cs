using System;
using System.Globalization;
using System.Windows.Data;

namespace MediviaBotUI.Converters
{
    class CheckboxContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool)value ? "Enabled" : "Disabled";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
