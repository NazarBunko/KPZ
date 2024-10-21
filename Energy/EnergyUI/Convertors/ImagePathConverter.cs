using Energy;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace EnergyUI.Convertors
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (MeterStatus)value;
            var uri = new Uri(string.Format(@"/Images/Status/{0}.png", status), UriKind.Relative);
            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
