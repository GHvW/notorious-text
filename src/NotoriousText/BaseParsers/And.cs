namespace NotoriousText.BaseParsers; 

public class And<A, B> : IParser<(A, B)> {

    private readonly IParser<A> first;
    private readonly IParser<B> next;

    public And(IParser<A> first, IParser<B> next) {
        this.first = first;
        this.next = next;
    }

    public ((A, B), InputState)? Parse(InputState input) =>
        (from a in this.first
         from b in this.next
         select (a, b))
        .Parse(input);
}
