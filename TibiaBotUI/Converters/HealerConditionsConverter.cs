using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using TibiaBotUI.Models;

namespace TibiaBotUI.Converters
{
    public class HealerConditionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HealerConditions[] values = (HealerConditions[])value;
             return values.Select(v => v.ToString()).Select(s => Regex.Replace(s, @"([A-Z])", " $1"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
