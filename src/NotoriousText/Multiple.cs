using System.Collections.Immutable;

namespace NotoriousText; 

public class Multiple<A> : IParser<ImmutableStack<A>> {

    private readonly IParser<A> parser;
    
    public Multiple(IParser<A> parser) {
        this.parser = parser;
    }

    public (ImmutableStack<A>, InputState)? Parse(InputState input) =>
        (from item in this.parser
         from rest in new Multiple<A>(this.parser)
         select rest.Push(item))
        .Or(new Success<ImmutableStack<A>>(ImmutableStack<A>.Empty))
        .Parse(input);
}
