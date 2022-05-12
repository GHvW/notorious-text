using System;

using FluentAssertions;

using Xunit;
using NotoriousText;
using NotoriousText.BaseParsers;
using NotoriousText.WKTParsers;

namespace NotoriousText.Tests;

public class GivenAWKTPoint {

    public class AndThePointIsNOTEmpty {

        private readonly InputState input;
        public AndThePointIsNOTEmpty() {
            this.input = new InputState(0, "POINT(1 2)");
        }

        [Fact]
        public void WhenParsed() {
            var (result, rest) = new Point().Parse(this.input).Value;

            result.Should().Be(new Geometries.Point(1, 2));
            rest.Input.Should().Be("POINT(1 2)");
            rest.Position.Should().Be(10);
        }
    }

    public class AndThePointIsEmpty {

        private readonly string point;
        public AndThePointIsEmpty() {
            this.point = "POINT EMPTY";
        }

        [Fact]
        public void WhenParsed() {

        }
    }
}
