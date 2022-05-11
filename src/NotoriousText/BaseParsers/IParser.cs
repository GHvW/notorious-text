namespace NotoriousText.BaseParsers;

public interface IParser<A> {
    public (A, InputState)? Parse(InputState input);
}
