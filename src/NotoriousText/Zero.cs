namespace NotoriousText;

public record Zero<A>() : Parser<A> {
    public (A, InputState)? Parse(InputState input) =>
        null;
}
