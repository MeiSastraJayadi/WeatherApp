using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BruTile;
using BruTile.Predefined;
using BruTile.Web;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.Tiling.Layers;

namespace WeatherApp.Views.Pages;

public partial class MapView : UserControl
{

    private static readonly MPoint _startingPoint = 
        SphericalMercator.FromLonLat(106.8456, -6.2088).ToMPoint();

    private readonly MemoryLayer _pinLayer = new("Selected location")
    {
        Style = ImageStyles.CreatePinStyle(
            fillColor: Color.FromArgb(255, 32, 57, 85), 
            strokeColor: Color.White,
            symbolScale: 0.5
        )
    }; 

    private static HttpTileSource CreateEsriSource(string service, string name) =>
    new(
        new GlobalSphericalMercator(),
        "https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/"
            + service + "/MapServer/tile/{z}/{y}/{x}",
        name: name,
        attribution: new Attribution(
            "Esri, HERE, Garmin, © OpenStreetMap contributors, and the GIS user community",
            "https://www.esri.com/en-us/legal/terms/full-master-agreement"),
        configureHttpRequestMessage: request =>
            request.Headers.TryAddWithoutValidation("User-Agent", "WeatherApp/1.0"));
    
    public MapView()
    {
        InitializeComponent();

        _pinLayer.Features = new[] { new PointFeature(_startingPoint) };
        _pinLayer.DataHasChanged();

        Map map = new()
        {
            BackColor = Color.FromString("#F2F2F2")
        };

        map.Layers.Add(new TileLayer(
            CreateEsriSource("World_Light_Gray_Base", "Esri Light Gray Base")));

        map.Layers.Add(new TileLayer(
            CreateEsriSource("World_Light_Gray_Reference", "Esri Light Gray Labels")));

        map.Layers.Add(_pinLayer);
        map.Navigator.CenterOnAndZoomTo(_startingPoint, 1222);

        WeatherMap.Map = map;
    }
}