namespace NotoriousText.BaseParsers; 

public record Alpha : IParser<char> {
    
    public (char, InputState)? Parse(InputState input) =>
        new Satisfies(char.IsLetter).Parse(input);
}
