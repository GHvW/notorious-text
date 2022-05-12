using System.Collections.Immutable;

namespace NotoriousText.BaseParsers;

public record Space() : IParser<ImmutableStack<char>> {
    public (ImmutableStack<char>, InputState)? Parse(InputState input) =>
        new Multiple<char>(new Whitespace()).Parse(input);
}
