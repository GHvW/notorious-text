namespace NotoriousText; 

public class Bracket<A, B> : IParser<A> {

    private readonly IParser<A> parser;
    private readonly IParser<B> bracketParser;

    public Bracket(IParser<A> parser, IParser<B> bracketParser) {
        this.parser = parser;
        this.bracketParser = bracketParser;
    }

    public (A, InputState)? Parse(InputState input) =>
        (from _ in this.bracketParser
         from item in this.parser
         from _ in this.bracketParser
         select item)
        .Parse(input);
}
