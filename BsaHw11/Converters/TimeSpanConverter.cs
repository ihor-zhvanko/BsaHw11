using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BsaHw11.Converters
{
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            TimeSpan dt = TimeSpan.Parse(value.ToString());
            return dt.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            TimeSpan dt = TimeSpan.Parse(value.ToString(), CultureInfo.InvariantCulture);
            return dt;
        }
    }
}
