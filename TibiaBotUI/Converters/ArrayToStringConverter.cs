using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MediviaBotUI.Models;

namespace MediviaBotUI.Converters
{
    public class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder result = new StringBuilder();
            if (value?.GetType() == typeof(ObservableCollection<Spell>))
            {
                ObservableCollection<Spell> spells = (ObservableCollection<Spell>)value;
                for (int i = 0; i < spells.Count; i++)
                {
                    result.Append(spells[i].Name);

                    if (i < spells.Count-1)
                        result.Append(", ");
                }
                return result.ToString();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
