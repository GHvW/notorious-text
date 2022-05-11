namespace NotoriousText.BaseParsers; 

public class Bind<A, B> : IParser<B> {

    private readonly IParser<A> parser;
    private readonly Func<A, IParser<B>> fn;
    
    public Bind(IParser<A> parser, Func<A, IParser<B>> fn) {
        this.fn = fn;
        this.parser = parser;
    }

    public (B, InputState)? Parse(InputState input) =>
        this.parser.Parse(input) switch {
            null => null,
            (var item, var rest) => this.fn(item).Parse(rest)
        };
}
