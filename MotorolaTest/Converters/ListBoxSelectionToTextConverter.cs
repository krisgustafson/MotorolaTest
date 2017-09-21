using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;


namespace MotorolaTest.Converters
{
    /// <summary>
    /// Converter for a value (a List of Model objects) to a possibly multi-line string
    /// </summary>
    public class ListBoxSelectionToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<Model>)
            {
                IList<Model> list = value as IList<Model>;
                if (list.Count == 0)
                {
                    return string.Empty;
                }

                StringBuilder outText = new StringBuilder();
                foreach(Model mod in list)
                {
                    outText.AppendLine(mod.Item);
                }
                return outText.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
