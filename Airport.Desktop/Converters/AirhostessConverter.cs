using Airport.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Airport.Desktop.Converters
{
    public class AirhostessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var airhostess = value as Airhostess;
            if (value as Airhostess == null)
                return null;

            return $"{airhostess.FirstName} {airhostess.LastName}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
