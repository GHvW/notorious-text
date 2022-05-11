namespace NotoriousText.BaseParsers; 

public class Or<A> : IParser<A> {

    private readonly IParser<A> first;
    private readonly IParser<A> other;

    public Or(IParser<A> first, IParser<A> other) {
        this.first = first;
        this.other = other;
    }

    public (A, InputState)? Parse(InputState input) =>
        this.first.Parse(input) ?? this.other.Parse(input);
}
