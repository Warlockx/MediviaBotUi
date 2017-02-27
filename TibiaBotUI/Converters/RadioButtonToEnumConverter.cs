using System;
using System.Globalization;
using System.Windows.Data;

namespace MediviaBotUI.Converters
{
    public class RadioButtonToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return null;

            var test = Enum.Parse(targetType, parameter.ToString());
            return test;

        }
    }
    }

