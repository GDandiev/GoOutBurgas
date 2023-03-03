using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace GoOutBurgas.Pages;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
    }
        Pin pin = new Pin
        {
            Label = "Santa Cruz",
            Address = "The city with a boardwalk",
            Type = PinType.Place,
            Location = new Location(36.9628066, -122.0194722)
        };
       //Map.Pins.Add(pin);	
}