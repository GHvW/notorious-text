using NotoriousText.BaseParsers;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenAWKTMultiPoint {

    private readonly InputState input;
    private readonly InputState altInput;

    public GivenAWKTMultiPoint() {
        this.input = new InputState(0, "MULTIPOINT(10 40, 42 30, 20 15, 11 12)");
        this.input = new InputState(0, "MULTIPOINT((10 40), (42 30), (20 15), (11 12))");
    }

    [Fact]
    public void WhenParsingATraditionalMultipoint() {
        // var (result, rest) = 
    }
}
