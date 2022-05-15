using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NotoriousText.BaseParsers;
using NotoriousText.WKTParsers;

using Xunit;

namespace NotoriousText.Tests; 

// TODO - try changing tests to theory
public class GivenAWKTPolygon {

    private readonly InputState simplePolygon;
    private readonly Geometries.Polygon expected;

    public GivenAWKTPolygon() {
        this.simplePolygon = new InputState(0, "POLYGON ((30 10, 40 41, 20 45, 11 25, 33 15))");
        this.expected = new Geometries.Polygon(new List<IEnumerable<Geometries.Point>>() {
            new List<Geometries.Point>() {
                new(30, 10), new(40, 41), new(20, 45), new(11, 25), new(33, 15)
            }
        });
    }

    [Fact]
    public void WhenParsed() {
        var (result, rest) = new PolygonText().Parse(this.simplePolygon).Value;

        foreach (var (polygon, expectedPoly) in result.Points.Zip(this.expected.Points)) {
            foreach (var (item, expectedItem) in polygon.Zip(expectedPoly)) {
                item.Should().Be(expectedItem);
            }

            rest.Position.Should().Be(45);
        }
    }

    public class WithInnerPolygons {
        
        private readonly InputState complexPolygon;
        private readonly Geometries.Polygon expected;

        public WithInnerPolygons() {
            this.complexPolygon = new InputState(0, "POLYGON ((30 10, 40 41, 20 45, 11 25, 33 15), (27 37, 39 49, 98 87, 4 103))");
            this.expected = new Geometries.Polygon(new List<IEnumerable<Geometries.Point>>() {
                new List<Geometries.Point>() {
                    new(30, 10), new(40, 41), new(20, 45), new(11, 25), new(33, 15)
                },
                new List<Geometries.Point>() {
                    new(27, 37), new(39, 49), new(98, 87), new(4, 103)
                }
            });
        }

        [Fact]
        public void WhenParsed() { 
            var (result, rest) = new PolygonText().Parse(this.complexPolygon).Value; 
            
            foreach (var (polygon, expectedPoly) in result.Points.Zip(this.expected.Points)) { 
                foreach (var (item, expectedItem) in polygon.Zip(expectedPoly)) { 
                    item.Should().Be(expectedItem); 
                }
                
                rest.Position.Should().Be(75);
            }           
        }
    }
}
