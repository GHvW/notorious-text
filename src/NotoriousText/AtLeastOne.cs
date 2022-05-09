using System.Collections.Immutable;

namespace NotoriousText; 

public class AtLeastOne<A> : IParser<ImmutableList<A>> {

    private readonly IParser<A> parser;

    public AtLeastOne(IParser<A> parser) {
        this.parser = parser;
    }

    public (ImmutableList<A>, InputState)? Parse(InputState input) =>
        (from item in this.parser
         from rest in new Multiple<A>(this.parser)
         select rest.Add(item))
        .Parse(input);
}
