using System.Collections.Immutable;

using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record MultiPoint() : IParser<ImmutableStack<(double, double)>> {

    public (ImmutableStack<(double, double)>, InputState)? Parse(InputState input) =>
        new Point()
            .AtLeastOneSeparatedBy(new Token<char>(new Character(',')))
            .Parse(input);
}
