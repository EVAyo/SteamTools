using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using FluentAvalonia.UI.Media;
using System;
using System.Globalization;

namespace System.Application.Converters
{
    public class IsVisibleToOpacity : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double defaultOpacity = 1;
            if (parameter is double d)
            {
                defaultOpacity = d;
            }

            if (value is bool b)
            {
                return b ? defaultOpacity : 0;
            }

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return d > 0;
            }
            return BindingOperations.DoNothing;
        }
    }
}
