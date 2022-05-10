namespace NotoriousText;

public record NaturalNumber() : IParser<int> {
    
    public (int, InputState)? Parse(InputState input) =>
        new AtLeastOne<char>( new Digit())
            .Select(it =>
                it.Aggregate(0, (acc, c) => 10 * acc + (c -'0')))
            .Parse(input);
}
