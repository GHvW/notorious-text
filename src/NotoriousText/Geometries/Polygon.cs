using System.Collections.Immutable;

namespace NotoriousText.Geometries;

public record Polygon(IEnumerable<IEnumerable<Point>> Points);
