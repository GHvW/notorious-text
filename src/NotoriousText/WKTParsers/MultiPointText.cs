using NotoriousText.BaseParsers;
using NotoriousText.Geometries;

namespace NotoriousText.WKTParsers;

public record MultiPointText() : IParser<Geometries.MultiPoint> {
    
    public (Geometries.MultiPoint, InputState)? Parse(InputState input) =>
        new Str("MULTIPOINT")
            .SelectMany(_ => 
                new PointSeq()
                    .Between(new OpenParen(), new CloseParen())
                    .Select(points => new Geometries.MultiPoint(points)))
            .Parse(input);
}
