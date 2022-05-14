namespace NotoriousText.BaseParsers;

public record RationalNumber() : IParser<double> {
    public (double, InputState)? Parse(InputState input) =>
        (from a in new NaturalNumber()
         from _ in new Character('.')
         from b in new DecimalNumber()
         select a + b)
        .Or(new NaturalNumber().Select(Convert.ToDouble))
        .Parse(input);
}

public record DecimalNumber() : IParser<double> {
    
    public (double, InputState)? Parse(InputState input) =>
        new AtLeastOne<char>(new Digit())
            .Select(digits =>
                digits
                    .Zip(Enumerable.Range(1, int.MaxValue))
                    .Aggregate(0.0, (acc, data) => {
                        var (c, i) = data;
                        var divisor = Convert.ToDouble(Math.Pow(10, i));
                        return acc + (Convert.ToDouble(c - '0') / divisor);
                    }))
            .Parse(input);
}