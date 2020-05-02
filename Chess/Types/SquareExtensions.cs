/*
ChessLib, a chess data structure library

MIT License

Copyright (c) 2017-2020 Rudy Alex Kohn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Chess.Test")]

namespace Rudz.Chess.Types
{
    using Enums;
    using System.Runtime.CompilerServices;

    public static class SquareExtensions
    {
        private static readonly string[] SquareStrings =
        {
            "a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1",
            "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2",
            "a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3",
            "a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4",
            "a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5",
            "a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6",
            "a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7",
            "a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(this Square s) => s.Value >= Squares.a1 && s.Value <= Squares.h8;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidEp(this Square s) => s.Rank() == Ranks.Rank3 || s.Rank() == Ranks.Rank6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidEp(this Square s, Player c) => s.RelativeRank(c) == Ranks.Rank3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDark(this Square s) => (s & BitBoards.DarkSquares) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char RankChar(this Square s) => s.Rank().Char;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char FileChar(this Square s) => s.File().FileChar();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetSquareString(this Square s) => SquareStrings[s.AsInt()];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPromotionRank(this Square square) => (BitBoards.PromotionRanksBB & square) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BitBoard BitBoardSquare(this Square sq) => BitBoards.BbSquares[sq.AsInt()];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BitBoard BitBoardSquare(this Squares sq) => BitBoards.BbSquares[(int)sq];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Square RelativeSquare(this Squares sq, Player c) => (int)sq ^ (c.Side * 56);
    }
}