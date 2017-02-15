using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TibiaBotUI.Converters
{
    public class FlyoutMultiBindingIsOpenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool flyoutEnabled = (bool)values[0];
            int tabIndex = (int)values[1];
            string flyoutName = (string)parameter;
            if (flyoutEnabled && flyoutName == "Spell" && tabIndex == 0)
                return true;
            return flyoutEnabled && flyoutName == "Item" && tabIndex == 1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string flyoutName = (string)parameter;
            if (flyoutName == "Spell")
                return new[] {value, 0};
            return flyoutName == "Item" ? new[] {value, 1} : new[] {value, 0};
        }
    }
}
