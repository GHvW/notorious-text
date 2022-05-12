using NotoriousText.BaseParsers;

namespace NotoriousText.WKTParsers;

public record MultiPointText() : IParser<Geometries.MultiPoint> {
    
    public (Geometries.MultiPoint, InputState)? Parse(InputState input) =>
        throw new NotImplementedException();
}
