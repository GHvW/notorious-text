using FluentAssertions;

using NotoriousText.BaseParsers;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenInputBetweenBraces {
    
    [Fact]
    public void WhenParsingTheItemBetweenBraces() {
        var input = new InputState(0, "(123)");
        
        var (result, rest) = 
            new NaturalNumber()
                .Between(new Character('('), new Character(')'))
                .Parse(input)
                .Value;

        result.Should().Be(123);
        rest.Position.Should().Be(5);
        rest.Input.Should().Be("(123)");
    }
    
}
