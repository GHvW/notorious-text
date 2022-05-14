using System;


namespace NotoriousText.Geometries;

public record Point(double X, double Y);

public static class PointOps {
    public static Point Create(this (double, double) @this) =>
        new Point(@this.Item1, @this.Item2);
}