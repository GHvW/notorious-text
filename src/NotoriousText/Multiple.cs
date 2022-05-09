using System.Collections.Immutable;

namespace NotoriousText; 

public class Multiple<A> : IParser<ImmutableList<A>> {

    private readonly IParser<A> parser;
    
    public Multiple(IParser<A> parser) {
        this.parser = parser;
    }

    public (ImmutableList<A>, InputState)? Parse(InputState input) =>
        (from item in this.parser
         from rest in new Multiple<A>(this.parser)
         select rest.Add(item))
        .Or(new Success<ImmutableList<A>>(ImmutableList.Create<A>()))
        .Parse(input);
}