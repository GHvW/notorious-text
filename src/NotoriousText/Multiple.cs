namespace NotoriousText; 

public class Multiple<A> : IParser<IReadOnlyCollection<A>> {

    private readonly IParser<A> parser;
    
    public Multiple(IParser<A> parser) {
        this.parser = parser;
    }

    public (IReadOnlyCollection<A>, InputState)? Parse(InputState input) {
        var results = new List<A>();
        var nextInput = input;
        var nextResult = this.parser.Parse(input);
        while (nextResult.HasValue) {
            var (item, remaining) = nextResult.Value;
            results.Add(item);
            nextInput = remaining;
            nextResult = this.parser.Parse(remaining);
        }

        return (results, nextInput);
    }

}
