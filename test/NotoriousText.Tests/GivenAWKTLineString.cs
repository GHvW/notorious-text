using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NotoriousText.BaseParsers;
using NotoriousText.WKTParsers;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenAWKTLineString {

    private readonly InputState input;
    private readonly Geometries.LineString expected;

    public GivenAWKTLineString() {
        this.input = new InputState(0, "LINESTRING (30 10, 11 31, 40 41)");
        this.expected = new Geometries.LineString(new List<Geometries.Point>() {
            new(30, 10), new(11, 31), new(40, 41)
        });
    }

    [Fact]
    public void WhenParsed() {
        var (result, rest) = new LineStringText().Parse(this.input).Value;

        foreach (var (item, expectedItem) in result.Points.Zip(this.expected.Points)) {
            item.Should().Be(expectedItem);
        }
    }
}
