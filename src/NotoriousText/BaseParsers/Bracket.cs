namespace NotoriousText.BaseParsers; 

public class Bracket<A, B, C> : IParser<A> {

    private readonly IParser<A> parser;
    private readonly IParser<B> openBracket;
    private readonly IParser<C> closeBracket;

    public Bracket(
        IParser<A> parser, 
        IParser<B> openBracket, 
        IParser<C> closeBracket) {
            this.parser = parser;
            this.openBracket = openBracket;
            this.closeBracket = closeBracket;
        }

    public (A, InputState)? Parse(InputState input) =>
        (from _open in this.openBracket
         from item in this.parser
         from _close in this.closeBracket
         select item)
        .Parse(input);
}
