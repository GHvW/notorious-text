using System.Collections.Immutable;

using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record PolygonText() : IParser<Geometries.Polygon> {

    public (Geometries.Polygon, InputState)? Parse(InputState input) =>
        new Token<string>(new Str("POLYGON"))
            .SelectMany(_ =>
                new PointSeq()
                    .Between(new OpenParen(), new CloseParen())
                    .AtLeastOneSeparatedBy(new Token<char>(new Character(',')))
                    .Between(new OpenParen(), new CloseParen())
                    .Select(it => new Geometries.Polygon(it)))
            .Parse(input);
}
