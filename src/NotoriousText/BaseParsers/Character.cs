namespace NotoriousText.BaseParsers; 

public class Character : IParser<char> {

    private readonly char c;

    public Character(char c) {
        this.c = c;
    }

    public (char, InputState)? Parse(InputState input) =>
        new Satisfies(it => it == this.c).Parse(input);
}
