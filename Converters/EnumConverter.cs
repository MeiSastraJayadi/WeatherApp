using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace WeatherApp.Converters;

public class EnumConverter : IValueConverter
{
    public object Convert(
        object? value, Type targetType, 
        object? parameter, CultureInfo culture
    )
        => value is not null && value.Equals(parameter);

    public object ConvertBack(
        object? value, Type targetType, 
        object? parameter, CultureInfo info
    )
        => throw new NotSupportedException();


}
