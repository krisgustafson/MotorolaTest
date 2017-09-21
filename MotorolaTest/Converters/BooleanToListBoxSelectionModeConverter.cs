using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;


namespace MotorolaTest.Converters
{
    /// <summary>
    /// Converter for a Boolean value to a list box selector type: Single or Multiple
    /// </summary>
    public class BooleanToListBoxSelectionModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool selectMode = (bool)value;
                return (bool)value ? SelectionMode.Multiple : SelectionMode.Single;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
