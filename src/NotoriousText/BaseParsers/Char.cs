namespace NotoriousText.BaseParsers; 

public class Char : IParser<char> {

    private readonly char c;

    public Char(char c) {
        this.c = c;
    }

    public (char, InputState)? Parse(InputState input) =>
        new Satisfies(it => it == this.c).Parse(input);
}
