using System;

using Xunit;

namespace NotoriousText.Tests;

public class GivenAWKTPoint {

    public class AndThePointIsNOTEmpty {

        private readonly string point;
        public AndThePointIsNOTEmpty() {
            this.point = "POINT(1 2)";
        }

        [Fact]
        public void WhenParsed() {

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
