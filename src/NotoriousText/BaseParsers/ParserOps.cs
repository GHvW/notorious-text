using System.Collections.Immutable;

namespace NotoriousText.BaseParsers; 

public static class ParserOps {

    public static IParser<B> Select<A, B>(this IParser<A> parser, Func<A, B> fn) =>
        new Map<A, B>(parser, fn);
    
    public static IParser<B> SelectMany<A, B>(this IParser<A> parser, Func<A, IParser<B>> fn) =>
        new Bind<A, B>(parser, fn);
    
    public static IParser<C> SelectMany<A, B, C>(
        this IParser<A> parser, 
        Func<A, IParser<B>> fn, 
        Func<A, B, C> selector) =>
            new BindWithSelector<A,B,C>(parser, fn, selector);

    public static IParser<A> Or<A>(this IParser<A> first, IParser<A> other) =>
        new Or<A>(first, other);

    public static IParser<A> Between<A, B, C>(this IParser<A> parser, IParser<B> openBracket, IParser<C> closeBracket) =>
        new Bracket<A, B, C>(parser, openBracket, closeBracket);

    public static IParser<(A, B)> And<A, B>(this IParser<A> first, IParser<B> next) =>
        new And<A, B>(first, next);
    
    public static IParser<ImmutableStack<A>> AtLeastOneSeparatedBy<A, B>(this IParser<A> first, IParser<B> separator) =>
        new AtLeastOneSeparatedBy<A, B>(first, separator);
}
