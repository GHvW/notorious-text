namespace NotoriousText.BaseParsers;

public record Zero<A>() : IParser<A> {
    public (A, InputState)? Parse(InputState input) =>
        null;
}
