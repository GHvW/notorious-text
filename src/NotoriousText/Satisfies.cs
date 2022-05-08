namespace NotoriousText; 

public class Satisfies : IParser<char> {

    private readonly Predicate<char> predicate;
    
    public Satisfies(Predicate<char> predicate) {
        this.predicate = predicate;
    }

    public (char, InputState)? Parse(InputState input) =>
        new Item()
            .SelectMany<char, char>(it =>
                this.predicate(it) 
                    ? new Success<char>(it) 
                    : new Zero<char>())
            .Parse(input);
}
