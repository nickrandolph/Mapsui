﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Providers;
using Mapsui.Tiling;
using Mapsui.UI;
using NetTopologySuite.Geometries;

namespace Mapsui.Samples.Common.Maps
{
    public class MutatingTriangleSample : ISample, ISampleTest, IDisposable
    {
        public string Name => "Mutating triangle";
        public string Category => "Special";

        public void Setup(IMapControl mapControl)
        {
            mapControl.Map = CreateMap();
        }

        private static readonly Random Random = new Random(0);
        private static CancellationTokenSource cancelationTokenSource;

        public static Map CreateMap()
        {
            cancelationTokenSource = new CancellationTokenSource();
            var map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            map.Layers.Add(CreateMutatingTriangleLayer(map.Extent));
            return map;
        }

        private static ILayer CreateMutatingTriangleLayer(MRect? envelope)
        {
            var layer = new MemoryLayer();

            var polygon = new Polygon(new LinearRing(GenerateRandomPoints(envelope, 3).ToArray()));
            var feature = new GeometryFeature(polygon);
            var features = new List<IFeature>
            {
                feature
            };

            layer.DataSource = new MemoryProvider<IFeature>(features);

            PeriodicTask.Run(() => {
                feature.Geometry = new Polygon(new LinearRing(GenerateRandomPoints(envelope, 3).ToArray()));
                // Clear cache for change to show
                feature.RenderedGeometry.Clear();
                // Trigger DataChanged notification
                layer.DataHasChanged();
            },
            TimeSpan.FromMilliseconds(1000));

            return layer;
        }

        public static IEnumerable<Coordinate> GenerateRandomPoints(MRect? envelope, int count = 25)
        {
            var result = new List<Coordinate>();
            if (envelope == null)
                return result;

            for (var i = 0; i < count; i++)
            {
                result.Add(new Coordinate(
                    Random.NextDouble() * envelope.Width + envelope.Left,
                    Random.NextDouble() * envelope.Height + envelope.Bottom));
            }

            result.Add(result[0].Copy()); // close polygon by adding start point.

            return result;
        }

        public class PeriodicTask
        {
            public static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(period, cancellationToken);

                    if (!cancellationToken.IsCancellationRequested)
                        action();
                }
            }

            public static Task Run(Action action, TimeSpan period)
            {
                return Run(action, period, cancelationTokenSource.Token);
            }
        }

        public void InitializeTest()
        {
            cancelationTokenSource.Cancel();
        }

        public void Dispose()
        {
            cancelationTokenSource.Cancel();
            cancelationTokenSource.Dispose();
        }
    }
}
