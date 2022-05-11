using NotoriousText.BaseParsers;

using System;

using Char = NotoriousText.BaseParsers.Char;

namespace NotoriousText.WKTParsers;

public class Point : IParser<Geometries.Point> {

    public (Geometries.Point, InputState)? Parse(InputState input) =>
        new Str("POINT")
            .SelectMany(_ =>
                new Token<int>(new NaturalNumber())
                    .And(new Token<int>(new NaturalNumber()))
                    .BracketedBy(new OpenParen(), new CloseParen())
                    .Select(data => new Point(data.Item1, data.Item2)))
            .Parse(input);
}

public record OpenParen() : IParser<char> {
    public (char, InputState)? Parse(InputState input) =>
        new Char('(').Parse(input);
}

public record CloseParen() : IParser<char> {
    public (char, InputState)? Parse(InputState input) =>
        new Char(')').Parse(input);
}