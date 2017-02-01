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
