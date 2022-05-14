using System;
using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public class Point : IParser<(double, double)> {

    public ((double, double), InputState)? Parse(InputState input) =>
        new Token<double>(new RationalNumber())
            .And(new Token<double>(new RationalNumber()))
            .Parse(input);
}