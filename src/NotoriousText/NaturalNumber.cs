namespace NotoriousText;

public record NaturalNumber() : IParser<uint> {
    public (uint, InputState)? Parse(InputState input) =>
        new Digit()
            .Select(it => UInt32.Parse(it.ToString()))
            .Parse(input);
}
