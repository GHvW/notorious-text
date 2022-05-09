namespace NotoriousText; 

public class Token<A> : IParser<A> {

    private readonly IParser<A> parser;

    public Token(IParser<A> parser) {
        this.parser = parser;
    }

    public (A, InputState)? Parse(InputState input) =>
        (from item in this.parser
         from _ in new Whitespace()
         select item)
        .Parse(input);
}
