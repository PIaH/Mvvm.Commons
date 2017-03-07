using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MvvmCommons.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var visibility = Visibility.Collapsed;
            if (value != null)
            {
                bool isOk = false;
                if (bool.TryParse(value.ToString(), out isOk))
                {
                    if (isOk)
                    {
                        visibility = Visibility.Visible;
                    }
                    else
                    {
                        visibility = Visibility.Collapsed;
                    }
                }
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not Supported
            return null;
        }
    }
}
