namespace NotoriousText; 

public class Bind<A, B> : Parser<B> {

    private readonly Parser<A> parser;
    private readonly Func<A, Parser<B>> fn;
    
    public Bind(Parser<A> parser, Func<A, Parser<B>> fn) {
        this.fn = fn;
        this.parser = parser;
    }

    public (B, InputState)? Parse(InputState input) =>
        this.parser.Parse(input) switch {
            null => null,
            (var item, var rest) => this.fn(item).Parse(rest)
        };
}
