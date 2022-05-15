using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record LineStringText() : IParser<Geometries.LineString> {
    
    public (Geometries.LineString, InputState)? Parse(InputState input) =>
        new Token<string>(new Str("LINESTRING"))
            .SelectMany(_ => 
                new PointSeq()
                    .Between(new OpenParen(), new CloseParen())
                    .Select(it => new Geometries.LineString(it)))
            .Parse(input);
}
