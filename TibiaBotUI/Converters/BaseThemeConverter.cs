using System;
using System.Globalization;
using System.Windows.Data;
using MediviaBotUI.Models;

namespace MediviaBotUI.Converters
{
    public class BaseThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return ThemeBaseColors.BaseDark;
            return (ThemeBaseColors)value == ThemeBaseColors.BaseDark; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return ThemeBaseColors.BaseDark; 
            return (bool)value ? ThemeBaseColors.BaseDark : ThemeBaseColors.BaseLight;
        }
    }
}
