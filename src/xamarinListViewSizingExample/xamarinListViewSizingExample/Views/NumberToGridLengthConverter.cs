using System;
using System.Globalization;
using Xamarin.Forms;

namespace xamarinListViewSizingExample.Views
{
    internal class NumberToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double numberValue))
            {
                throw new Exception($"Type {value.GetType().FullName} cannot be converted to GridLenght");
            }

            return new GridLength(numberValue, GridUnitType.Absolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is GridLength gridLength))
            {
                throw new Exception($"Type {value.GetType().FullName} is not GridLenght");
            }

            return gridLength.Value;
        }
    }
}
