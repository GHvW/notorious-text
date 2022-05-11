namespace NotoriousText.BaseParsers;

public record Digit() : IParser<char> {
    public (char, InputState)? Parse(InputState input) =>
        new Satisfies(char.IsDigit).Parse(input);
}
