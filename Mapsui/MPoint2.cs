﻿using Mapsui.Utilities;

namespace Mapsui;

public class MPoint2
{
    public double X { get; set; }
    public double Y { get; set; }
    public MRect MRect => new MRect(X, Y, X, Y);

    public MPoint Copy()
    {
        return new MPoint(X, Y);
    }

    public double Distance(MPoint point)
    {
        return Algorithms.Distance(X, Y, point.X, point.Y);
    }

    public bool Equals(MPoint? point)
    {
        if (point == null) return false;
        return X == point.X && Y == point.Y;
    }

    public int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public MPoint Offset(double offsetX, double offsetY)
    {
        return new MPoint(X + offsetX, Y + offsetY);
    }

    /// <summary>
    ///     Calculates a new point by rotating this point clockwise about the specified center point
    /// </summary>
    /// <param name="degrees">Angle to rotate clockwise (degrees)</param>
    /// <param name="centerX">X coordinate of point about which to rotate</param>
    /// <param name="centerY">Y coordinate of point about which to rotate</param>
    /// <returns>Returns the rotated point</returns>
    public MPoint Rotate(double degrees, double centerX, double centerY)
    {
        // translate this point back to the center
        var newX = X - centerX;
        var newY = Y - centerY;

        // rotate the values
        var p = Algorithms.RotateClockwiseDegrees(newX, newY, degrees);

        // translate back to original reference frame
        newX = p.X + centerX;
        newY = p.Y + centerY;

        return new MPoint(newX, newY);
    }

    /// <summary>
    ///     Calculates a new point by rotating this point clockwise about the specified center point
    /// </summary>
    /// <param name="degrees">Angle to rotate clockwise (degrees)</param>
    /// <param name="center">MPoint about which to rotate</param>
    /// <returns>Returns the rotated point</returns>
    public MPoint Rotate(double degrees, MPoint center)
    {
        return Rotate(degrees, center.X, center.Y);
    }
}
