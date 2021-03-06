namespace NotoriousText.BaseParsers;

public record Int() : IParser<int> {

    public (int, InputState)? Parse(InputState input) =>
        (from _ in new Character('-')
         from n in new NaturalNumber()
         select -n)
        .Or(new NaturalNumber())
        .Parse(input);
}
