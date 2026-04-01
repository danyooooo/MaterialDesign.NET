using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MaterialDesign.NET.Converters
{
    public class CircularProgressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 || 
                !(values[0] is double value) || 
                !(values[1] is double min) || 
                !(values[2] is double max))
            {
                return DoubleCollection.Parse("0, 100");
            }

            if (max <= min) return DoubleCollection.Parse("0, 100");

            // Parameter should be the full dash length (Circumference / StrokeThickness)
            // Default to 100 if not provided or parse error
            double fullDashLength = 100;
            if (parameter is string paramStr && double.TryParse(paramStr, out double p))
            {
                fullDashLength = p;
            }

            double percent = (value - min) / (max - min);
            if (percent < 0) percent = 0;
            if (percent > 1) percent = 1;

            double dashLength = percent * fullDashLength;
            double gapLength = fullDashLength; // Gap can be full circle to ensure it hides the rest

            // Return "dashLength, gapLength"
            return new DoubleCollection { dashLength, gapLength };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
