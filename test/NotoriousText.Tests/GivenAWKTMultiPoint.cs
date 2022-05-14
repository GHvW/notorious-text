using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NotoriousText.BaseParsers;
using NotoriousText.WKTParsers;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenAWKTMultiPoint {

    private readonly InputState input;
    private readonly InputState altInput;
    private readonly Geometries.MultiPoint expected;

    public GivenAWKTMultiPoint() {
        this.input = new InputState(0, "MULTIPOINT(10 40, 42 30, 20 15, 11 12)");
        this.altInput = new InputState(0, "MULTIPOINT((10 40), (42 30), (20 15), (11 12))");
        this.expected = 
            new Geometries.MultiPoint(
                new List<Geometries.Point>() { 
                    new Geometries.Point(10.0, 40.0), 
                    new Geometries.Point(42.0, 30.0),
                    new Geometries.Point(20.0, 15.0),                                                
                    new Geometries.Point(11.0, 12.0),                                                                                                 
                });
    }

    [Fact]
    public void WhenParsingATraditionalMultipoint() {
        var (result, rest) = new MultiPointText().Parse(this.input).Value;

        foreach (var (item, expectedItem) in result.Points.Zip(this.expected.Points)) {
            item.Should().Be(expectedItem);
        }

        rest.Position.Should().Be(38);
    }
}
