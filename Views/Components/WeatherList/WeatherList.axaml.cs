using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class WeatherList : ContentControl
{
    public static readonly StyledProperty<string> DayProperty = 
        AvaloniaProperty.Register<WeatherList, string>(nameof(Day), string.Empty);

    public static readonly StyledProperty<IImage> ImageProperty = 
        AvaloniaProperty.Register<WeatherList, IImage>(nameof(Image));

    public static readonly StyledProperty<int> MinTemperatureProperty = 
        AvaloniaProperty.Register<WeatherList, int>(nameof(MinTemperature), 0);

    public static readonly StyledProperty<int> MaxTemperatureProperty = 
        AvaloniaProperty.Register<WeatherList, int>(nameof(MaxTemperature), 0);

    public string Day
    {
        get => GetValue(DayProperty);
        set => SetValue(DayProperty, value);
    }

    public IImage Image
    {
        get => GetValue(ImageProperty); 
        set => SetValue(ImageProperty, value); 
    }

    public int MinTemperature
    {
        get => GetValue(MinTemperatureProperty); 
        set => SetValue(MinTemperatureProperty, value);
    }

    public int MaxTemperature
    {
        get => GetValue(MaxTemperatureProperty); 
        set => SetValue(MaxTemperatureProperty, value);
    }
}