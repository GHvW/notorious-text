using System;

namespace NotoriousText.Geometries;

public record Point(double X, double Y) {
    
    public static Point Create((double, double) it) =>
        new (it.Item1, it.Item2);
}