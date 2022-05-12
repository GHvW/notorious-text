using System.Collections.Immutable;
using System.Linq;

using FluentAssertions;

using NotoriousText.BaseParsers;

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
    public void WhenParsingASingleItemInput() {
        var theInput = new InputState(0, "a");
        var (result, rest) = new Item().Parse(theInput).Value;

        result.Should().Be('a');
        rest.Position.Should().Be(1);
        rest.Input.Should().Be("a");
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
        var (result, rest) = new Character('h').Parse(this.input).Value;

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

    [Fact]
    public void WhenBinding() {
         var (result, rest) = 
             (from h in new Character('h')
              from e in new Character('e')
              select h.ToString() + e.ToString())
             .Parse(this.input)
             .Value;

         result.Should().Be("he");
         rest.Input.Should().Be("hello world!");
         rest.Position.Should().Be(2);       
    }

    [Fact]
    public void WhenParsingAString() {
        var (result, rest) =
            new Str("hello").Parse(this.input).Value;

        result.Should().Be("hello");
        rest.Position.Should().Be(5);
        rest.Input.Should().Be("hello world!");
    }

    [Fact]
    public void WhenParsingAnEmptyString() {
        var (result, rest) =
            new Str("").Parse(this.input).Value;

        result.Should().Be("");
        rest.Position.Should().Be(0);
        rest.Input.Should().Be("hello world!");
    }
    
     [Fact]
     public void WhenParsingAStringAndAnotherString() {
         var (result, rest) =
             new Token<string>(new Str("hello"))
                 .And(new Str("world"))
                 .Parse(this.input)
                 .Value;
 
         result.Item1.Should().Be("hello");
         result.Item2.Should().Be("world");
         rest.Position.Should().Be(11);
         rest.Input.Should().Be("hello world!");
     }   
}
