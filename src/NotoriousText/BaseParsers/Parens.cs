namespace NotoriousText.BaseParsers; 

public class Braces {
    
}

public record OpenParen() : IParser<char> {
    public (char, InputState)? Parse(InputState input) =>
        new Character('(').Parse(input);
}

public record CloseParen() : IParser<char> {
    public (char, InputState)? Parse(InputState input) =>
        new Character(')').Parse(input);
}
