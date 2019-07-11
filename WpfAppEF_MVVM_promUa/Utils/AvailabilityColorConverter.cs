using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfAppEF_MVVM_promUa.Utils
{
    class AvailabilityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((int)value <= 0)
                {
                    return Brushes.Red;
                }
                return Brushes.Green;
            }
            return Brushes.Red; ;

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = string.Empty;
            foreach (char c in value.ToString())
            {
                if (char.IsDigit(c))
                {
                    res += c;
                }
            }
            if (res.Length > 0)
            {
                int quantity = 0;
                try
                {
                    quantity = System.Convert.ToInt32(res);
                }
                catch
                { }
                return quantity;

            }
            return 0;
        }
    }
}
