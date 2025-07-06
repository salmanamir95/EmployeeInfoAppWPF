using System;
using System.Globalization;
using System.Windows.Data;

namespace EmployeeInfoApp.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is char gender && parameter is string expected)
            {
                return gender.ToString() == expected;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked && parameter is string genderChar)
            {
                return genderChar[0];
            }
            return Binding.DoNothing;
        }
    }
}