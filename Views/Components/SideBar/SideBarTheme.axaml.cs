using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace WeatherApp;

public class SideBarTheme : ContentControl
{
    private static readonly StyledProperty<BoxShadows> BoxShadowsProperty = 
        AvaloniaProperty.Register<SideBarTheme, BoxShadows>(nameof(BoxShadow));
    
    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowsProperty);
        set => SetValue(BoxShadowsProperty, value);
    }
}