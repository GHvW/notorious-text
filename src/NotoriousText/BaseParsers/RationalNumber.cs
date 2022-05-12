namespace NotoriousText.BaseParsers;

public record RationalNumber() : IParser<double> {
    public (double, InputState)? Parse(InputState input) =>
        (from a in new NaturalNumber()
         from _ in new Character('.')
         from b in new NaturalNumber()
         select double.Parse($"{a}.{b}")) // TODO - something better
        .Parse(input);
}
