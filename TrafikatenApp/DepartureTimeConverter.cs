using System;
using System.Globalization;
using System.Windows.Data;

namespace TrafikantenApp
{
    public class DepartureTimeConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime departureTime = (DateTime)value;
            var minutes = (int)new TimeSpan(departureTime.Ticks - DateTime.Now.Ticks).TotalMinutes;
            if (minutes > 0 && minutes < 10) return minutes + " min";
            if (minutes == 0) return "nå";
            return departureTime.ToString("HH:mm", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
