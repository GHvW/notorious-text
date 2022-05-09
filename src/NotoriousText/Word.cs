using System.Collections.Immutable;

namespace NotoriousText;

public record Word() : IParser<ImmutableStack<char>> {
    public (ImmutableStack<char>, InputState)? Parse(InputState input) =>
        new AtLeastOne<char>(new Alpha()).Parse(input);
}
