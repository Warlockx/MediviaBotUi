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
            if (value == null)
                return null;

            if (value.GetType() == typeof(HealerConditions[]))
            {
                HealerConditions[] values = (HealerConditions[]) value;
                IEnumerable<string> test = values.Select(v => v.ToString()).Select(s => Regex.Replace(s, @"\B([A-Z])", " $1"));
                return test;
            }
            return Regex.Replace(value.ToString(), @"\B([A-Z])", " $1");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(HealerConditions), value?.ToString().Replace(" ",""));
        }
    }
}
