using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record LineStringText() : IParser<Geometries.LineString> {
    
    public (Geometries.LineString, InputState)? Parse(InputState input) =>
        new Token<string>(new Str("LINESTRING"))
            .SelectMany(_ => 
                new LineString()
                    .Between(new OpenParen(), new CloseParen())
                    .Select(Geometries.LineString.Create))
            .Parse(input);
}
