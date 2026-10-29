using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;

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

        _pinLayer.Features = new[] { new PointFeature(_startingPoint) };
        _pinLayer.DataHasChanged();

        Map map = new();
        map.Layers.Add(OpenStreetMap.CreateTileLayer("WeatherApp/1.0"));
        map.Layers.Add(_pinLayer);
        map.Navigator.CenterOnAndZoomTo(_startingPoint, 1222);

        WeatherMap.Map = map;
    }
}