namespace NotoriousText; 

public class BindWithSelector<A, B, C> : Parser<C> {

    private readonly Parser<A> parser;
    private readonly Func<A, Parser<B>> fn;
    private readonly Func<A, B, C> selector;
    
    public BindWithSelector(Parser<A> parser, Func<A, Parser<B>> fn, Func<A, B, C> selector) {
        this.fn = fn;
        this.parser = parser;
        this.selector = selector;
    }

    public (C, InputState)? Parse(InputState input) =>
        this.parser.Parse(input) switch {
            null => null,
            (var a, var rest) => this.fn(a).Parse(rest) switch {
                null => null,
                (var b, var leftover) => new Success<C>(this.selector(a, b)).Parse(leftover)
            }
        };
}
