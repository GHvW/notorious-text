using System.Collections.Immutable;

using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record MultiPoint() : IParser<ImmutableStack<(int, int)>> {

    public (ImmutableStack<(int, int)>, InputState)? Parse(InputState input) =>
        new Point()
            .AtLeastOneSeparatedBy(new Token<char>(new Character(',')))
            .Parse(input);
}
