using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace MotorolaTest.Converters
{
    /// <summary>
    /// Converter for a Boolean value to a visibility state (inverse of the normal BooleanToVisibilityConverter)
    /// </summary>
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
