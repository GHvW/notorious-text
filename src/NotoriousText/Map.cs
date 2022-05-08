namespace NotoriousText; 

public class Map<A, B> : IParser<B> {

    private readonly IParser<A> parser;
    private readonly Func<A, B> fn;
    public Map(IParser<A> parser, Func<A, B> fn) {
        this.fn = fn;
        this.parser = parser;
    }

    public (B, InputState)? Parse(InputState input) =>
        this.parser.Parse(input) switch {
            null => null,
            (var item, var rest) => (this.fn(item), rest)
        };
}
