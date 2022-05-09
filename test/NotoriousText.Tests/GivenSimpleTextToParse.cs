using System.Collections.Immutable;
using System.Linq;

using FluentAssertions;

using Xunit;

namespace NotoriousText.Tests; 

public class GivenSimpleTextToParse {

    private readonly InputState input;

    public GivenSimpleTextToParse() {
        this.input = new InputState(0, "hello world!");
    }
    
    [Fact]
    public void WhenParsingAnItem() {

        var (result, rest) = new Item().Parse(this.input).Value;

        result.Should().Be('h');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("hello world!");
    }
    
    [Fact]
    public void WhenSuccessIsParsed() {
        var (result, rest) = new Success<string>("success").Parse(this.input).Value;

        result.Should().Be("success");
        
        rest.Position.Should().Be(0);
        rest.Input.Should().Be("hello world!");
    }

    [Fact]
    public void WhenZeroIsParsed() {
        var result = new Zero<string>().Parse(this.input);

        result.Should().BeNull();
    }
    
    [Fact]
    public void WhenSuccessIsMapped() {
        var (result, rest) = new Success<string>("success").Select(it => it.ToUpper()).Parse(this.input).Value;

        result.Should().Be("SUCCESS");
        rest.Position.Should().Be(0);
        rest.Input.Should().Be("hello world!");
    }
    
    [Fact]
    public void WhenZeroIsMapped() {
        var result = new Zero<string>().Select(it => it.ToUpper()).Parse(this.input);

        result.Should().BeNull();
    }
    
    [Fact]
    public void WhenParsingToSatisfyACondition() {
        var (result, rest) = new Satisfies(it => it == 'h').Parse(this.input).Value;

        result.Should().Be('h');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("hello world!");
    }
    
    [Fact]
    public void WhenParsingOrForFirstChar() {
        var (result, rest) = new Satisfies(it => it == 'h').Or(new Success<char>('9')).Parse(this.input).Value;

        result.Should().Be('h');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("hello world!");
    }
    
    [Fact]
    public void WhenParsingOrMissingChar() {
        var (result, rest) = new Satisfies(it => it == '9').Or(new Satisfies(it => it == 'h')).Parse(this.input).Value;

        result.Should().Be('h');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("hello world!");
    }
    
    [Fact]
    public void WhenParsingChar() {
        var (result, rest) = new Char('h').Parse(this.input).Value;

        result.Should().Be('h');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("hello world!");
    }

    [Fact]
    public void WhenParsingAWord() {
        var (result, rest) = new Word().Parse(this.input).Value;

        foreach (var (item, i) in result.Zip(Enumerable.Range(0, int.MaxValue))) {
            item.Should().Be(this.input.Input[i]);
        }

        rest.Input.Should().Be("hello world!");
        rest.Position.Should().Be(5);
    }

    [Fact]
    public void WhenParsingAToken() {
        var (result, rest) = new Token<ImmutableStack<char>>(new Word()).Parse(this.input).Value;

        result.Aggregate("", (s, next) => s + next).Should().Be("hello");
        rest.Input.Should().Be("hello world!");
        rest.Position.Should().Be(6);
    }
}
