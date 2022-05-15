using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record PointSeq() : IParser<IEnumerable<Geometries.Point>> {

    public (IEnumerable<Geometries.Point>, InputState)? Parse(InputState input) =>
        new Point()
            .AtLeastOneSeparatedBy(new Token<char>(new Character(',')))
            .Select(it => it.Select(Geometries.Point.Create))
            .Parse(input);
}
