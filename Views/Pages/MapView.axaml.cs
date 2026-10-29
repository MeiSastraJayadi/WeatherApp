using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;

namespace WeatherApp.Views.Pages;

public partial class MapView : UserControl
{

    private static readonly MPoint _startingPoint = 
        SphericalMercator.FromLonLat(106.8456, -6.2088).ToMPoint();

    private readonly MemoryLayer _pinLayer = new("Selected location")
    {
        Style = new SymbolStyle
        {
            SymbolScale = 1.2, 
            Fill = new Brush(Color.OrangeRed), 
            Outline = new Pen(Color.White, 2)
        }
    }; 
    
    public MapView()
    {
        InitializeComponent();
    }
}