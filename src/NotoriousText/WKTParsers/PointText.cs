using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record PointText() : IParser<Geometries.Point> {
    
    // TODO - follow the BNF more closely
    // TODO - add ability to parse "POINT EMPTY"
    public (Geometries.Point, InputState)? Parse(InputState input) =>
        new Str("POINT")
            .SelectMany(_ =>
                new Point()
                    .Between(new OpenParen(), new CloseParen())
                    .Select(data => new Geometries.Point(data.Item1, data.Item2)))
            .Parse(input);
}
