﻿using Mapsui.Extensions;
using Mapsui.Projection;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.Utilities;
using Mapsui.Widgets.ScaleBar;

namespace Mapsui.Samples.Common.Maps.Widgets
{
    public class ScaleBarSample : ISample
    {
        public string Name => "1 ScaleBar";
        public string Category => "Widgets";

        public void Setup(IMapControl mapControl)
        {
            mapControl.Map = CreateMap();
        }

        public static Map CreateMap()
        {
            var map = new Map
            {
                CRS = "EPSG:3857",
                
            };
            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            var transformation = new MinimalTransformation();
            
            // Add many different ScaleBarWidgets to Viewport of Map
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { ScaleBarMode = ScaleBarMode.Both, MarginX = 10, MarginY = 10 });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Center, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom, TextAlignment = Mapsui.Widgets.Alignment.Center });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { MaxWidth = 200, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Right, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom, TextAlignment = Mapsui.Widgets.Alignment.Right, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = ImperialUnitConverter.Instance });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { TextColor = new Color(40, 15, 95, 128), Halo = new Color(30, 4, 122, 128), HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Center, TextAlignment = Mapsui.Widgets.Alignment.Right, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = NauticalUnitConverter.Instance });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { TextColor = Color.Black, Halo = Color.Gray, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Center, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Center, TextAlignment = Mapsui.Widgets.Alignment.Center, ScaleBarMode = ScaleBarMode.Both });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { Font = new Font { FontFamily = "serif", Size = 16 }, TextColor = new Color(222, 88, 66, 128), Halo = new Color(252, 208, 89, 128), HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Right, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Center, TextAlignment = Mapsui.Widgets.Alignment.Left, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = NauticalUnitConverter.Instance });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { Halo = Color.Gray, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Top, TextAlignment = Mapsui.Widgets.Alignment.Left, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = NauticalUnitConverter.Instance });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { TextColor = Color.Gray, Halo = Color.White, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Center, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Top, TextAlignment = Mapsui.Widgets.Alignment.Right, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = NauticalUnitConverter.Instance });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { TextColor = Color.Gray, Font = null, Halo = Color.White, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Right, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Top, TextAlignment = Mapsui.Widgets.Alignment.Right });
            map.Widgets.Add(new ScaleBarWidget(map, transformation) { MaxWidth = 250, ShowEnvelop = true, Font = new Font { FontFamily = "sans serif", Size = 24 }, TickLength = 15, TextColor = new Color(240, 120, 24, 128), Halo = new Color(250, 168, 48, 128), HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Top, TextAlignment = Mapsui.Widgets.Alignment.Left, ScaleBarMode = ScaleBarMode.Both, SecondaryUnitConverter = NauticalUnitConverter.Instance, MarginX = 100, MarginY = 100 });
            return map;
        }
    }
}