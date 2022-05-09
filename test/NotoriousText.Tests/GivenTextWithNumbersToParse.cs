using FluentAssertions;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenTextWithNumbersToParse {
    
    private readonly InputState input;

    public GivenTextWithNumbersToParse() {
        this.input = new InputState(0, "867-5309");
    }

    [Fact]
    public void WhenParsingADigit() {

        var (result, rest) = new Digit().Parse(this.input).Value;

        result.Should().Be('8');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("867-5309");
    }
    
    [Fact]
     public void WhenParsingANumber() {
 
         var (result, rest) = new NaturalNumber().Parse(this.input).Value;
 
         result.Should().Be(8);
         rest.Position.Should().Be(1);
         rest.Input.Should().Be("867-5309");
     }   
}
