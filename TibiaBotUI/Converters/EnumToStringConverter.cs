using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using MediviaBotUI.Models;

namespace MediviaBotUI.Converters
{
    public class EnumToStringConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            
            if (value.GetType() == typeof(TargetingStance[]))
            {
                TargetingStance[] values = (TargetingStance[])value;
                return values.Select(v => v.ToString()).Select(s => Regex.Replace(s, @"\B([A-Z])", " $1"));
            }
            if (value.GetType() == typeof(AttackMode[]))
            {
                AttackMode[] values = (AttackMode[])value;
                return values.Select(v => v.ToString()).Select(s => Regex.Replace(s, @"\B([A-Z])", " $1"));
            }
            if (value.GetType() == typeof(HealerConditions[]))
            {
                HealerConditions[] values = (HealerConditions[])value;
               return values.Select(v => v.ToString()).Select(s => Regex.Replace(s, @"\B([A-Z])", " $1"));
            }

            return Regex.Replace(value.ToString(), @"\B([A-Z])", " $1");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(targetType, value?.ToString().Replace(" ", ""));
        }
    }
}
