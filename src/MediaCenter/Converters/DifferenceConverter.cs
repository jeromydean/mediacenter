﻿using System.Globalization;
using System.Windows.Data;

namespace MediaCenter.Converters
{
  public class DifferenceConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (values.All(v => double.TryParse(v.ToString(), out _)))
      {
        double value = (double)values[0] - (double)values[1];
        return value;
      }
      return 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}