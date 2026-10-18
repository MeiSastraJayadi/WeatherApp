using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class SideBarTheme : ContentControl
{
    public static readonly StyledProperty<BoxShadows> BoxShadowProperty = 
        AvaloniaProperty.Register<SideBarTheme, BoxShadows>(nameof(BoxShadow));
    
    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }
}