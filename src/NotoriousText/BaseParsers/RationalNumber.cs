namespace NotoriousText.BaseParsers;

public record RationalNumber() : IParser<double> {
    public (double, InputState)? Parse(InputState input) =>
        (from a in new NaturalNumber()
         from _ in new Char('.')
         from b in new NaturalNumber()
         select)
        .Parse(input);
}
