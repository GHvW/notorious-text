using System;
using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public class Point : IParser<Geometries.Point> {

    // TODO - add ability to parse "POINT EMPTY"
    public (Geometries.Point, InputState)? Parse(InputState input) =>
        new Str("POINT")
            .SelectMany(_ =>
                new Token<int>(new NaturalNumber())
                    .And(new Token<int>(new NaturalNumber()))
                    .Between(new OpenParen(), new CloseParen())
                    .Select(data => new Geometries.Point(data.Item1, data.Item2)))
            .Parse(input);
}