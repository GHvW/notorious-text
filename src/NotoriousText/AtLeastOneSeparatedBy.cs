using System.Collections.Immutable;
using System.Threading.Tasks.Dataflow;

namespace NotoriousText; 

public class AtLeastOneSeparatedBy<A, B> : IParser<ImmutableStack<A>> {

    private readonly IParser<A> parser;
    private readonly IParser<B> separator;

    public AtLeastOneSeparatedBy(IParser<A> parser, IParser<B> separator) {
        this.parser = parser;
        this.separator = separator;
    }

    public (ImmutableStack<A>, InputState)? Parse(InputState input) =>
        (from first in this.parser
         from rest in new Multiple<A>(from _ in this.separator
                                                     from item in this.parser
                                                     select item)
         select rest.Push(first))
        .Parse(input);
}
