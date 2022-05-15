using System.Collections.Immutable;

namespace NotoriousText.Geometries;

public record LineString(IEnumerable<Point> Points) {
    
    public static LineString Create(ImmutableStack<(double, double)> points) =>
        new(points.Select(Geometries.Point.Create));
}
