namespace NotoriousText;

public record Whitespace() : IParser<char> {

    public (char, InputState)? Parse(InputState input) =>
        new Satisfies(char.IsWhiteSpace).Parse(input);
}
