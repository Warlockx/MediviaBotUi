using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MediviaBotUI.Models;

namespace MediviaBotUI.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TargetingStance)
                return (TargetingStance) value == TargetingStance.KeepAway ? Visibility.Visible : Visibility.Collapsed;

            if(value is bool)
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;



            if (value is int)
            {
                if (parameter == null)
                    return (int) value == 0 ? Visibility.Visible : Visibility.Collapsed;

                return value.ToString() == (string) parameter ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (Visibility)value == Visibility.Visible;
        }
    }
}
