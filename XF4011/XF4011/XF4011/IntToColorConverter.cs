using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XF4011
{
    class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is int)
            {
                int colorID = (int)value;
                if (colorID == 1) return Color.Yellow;
                else if (colorID == 2) return Color.Pink;
                else if (colorID == 3) return Color.Gray;
                else return Color.Red;
            }
           else
            {
                return Color.Azure;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
