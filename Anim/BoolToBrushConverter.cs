    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Media;

    namespace EmployeeInfoApp.Anim
    {
        public class BoolToBrushConverter : IValueConverter
        {
            public Brush TrueBrush { get; set; }
            public Brush FalseBrush { get; set; }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return ((bool)(value ?? false)) ? TrueBrush : FalseBrush;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                => throw new NotImplementedException();
        }
    }

    