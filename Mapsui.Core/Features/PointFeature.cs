﻿using System;

namespace Mapsui.Layers
{
    public class PointFeature : BaseFeature, IFeature
    {
        public PointFeature(MPoint point)
        {
            Point = point ?? throw new ArgumentNullException(nameof(point));
        }

        public PointFeature(double x, double y)
        {
            Point = new MPoint(x, y);
        }

        public MPoint Point { get; }
        public MRect Extent => Point.MRect;
    }
}