using NotoriousText.BaseParsers;

using System;


namespace NotoriousText.WKTParsers;

//public class Point : IParser<Geometries.Point> {

//    public (Geometries.Point, InputState)? Parse(InputState input) =>
//        new Str("POINT").SelectMany(_ =>
//            new Token(new NaturalNumber())
//                .And(new Token(new NaturalNumber()))
//                .BracketedBy(new OpenParen(), new CloseParen());
//}
