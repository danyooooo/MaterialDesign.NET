using System;
using System.Globalization;
using System.Windows.Data;

namespace MaterialDesign.NET.Converters
{
    /// <summary>
    /// Converts SelectedIndex to boolean: returns true if index != -1 (has selection)
    /// </summary>
    public class SelectedIndexToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                return index != -1;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
