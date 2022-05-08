namespace NotoriousText;

public interface Parser<A> {
    public (A, InputState)? Parse(InputState input);
}
