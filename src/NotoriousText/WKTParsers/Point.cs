using System;
using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public class Point : IParser<(int, int)> {

    public ((int, int), InputState)? Parse(InputState input) =>
        new Token<int>(new NaturalNumber())
            .And(new Token<int>(new NaturalNumber()))
            .Parse(input);
}