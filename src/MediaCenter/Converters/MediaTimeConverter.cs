using System.Globalization;
using System.Windows.Data;

namespace MediaCenter.Converters
{
  public class MediaTimeConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (values.Length == 2
        && long.TryParse(values[0].ToString(), out long length)
        && double.TryParse(values[1].ToString(), out double position))
      {
        return TimeSpan.FromMilliseconds(length * position).ToString(@"hh\:mm\:ss");
      }
      return string.Empty;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
