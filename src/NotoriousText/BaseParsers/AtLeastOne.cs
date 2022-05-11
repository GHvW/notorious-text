using System.Collections.Immutable;

namespace NotoriousText.BaseParsers; 

public class AtLeastOne<A> : IParser<ImmutableStack<A>> {

    private readonly IParser<A> parser;

    public AtLeastOne(IParser<A> parser) {
        this.parser = parser;
    }

    public (ImmutableStack<A>, InputState)? Parse(InputState input) =>
        (from item in this.parser
         from rest in new Multiple<A>(this.parser)
         select rest.Push(item))
        .Parse(input);
}
