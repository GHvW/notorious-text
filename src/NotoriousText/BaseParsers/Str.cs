using System;


namespace NotoriousText.BaseParsers;

public class Str : IParser<string> {

    private readonly string str;

    public Str(string str) {
        this.str = str;
    }

    public (string, InputState)? Parse(InputState input) =>
        (this.str switch {
            "" => new Success<string>(""),
            var s => (from _ in new Character(s[0])
                      from _rest in new Str(s[1..])
                      select s)
        })
        .Parse(input);
}
