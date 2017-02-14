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
            return (bool)values[0] && ((int)values[1] == 0 || parameter != null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            int result = (bool)value || parameter != null ? 1 : 0;

            return new [] { value, result };
        }
    }
}
