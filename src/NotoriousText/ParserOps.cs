namespace NotoriousText; 

public static class ParserOps {

    public static Parser<B> Select<A, B>(this Parser<A> parser, Func<A, B> fn) =>
        new Map(parser, fn);
}
