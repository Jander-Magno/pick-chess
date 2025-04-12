using System;
using pick_chess.board;
using pick_chess.Chess;

namespace pick_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('a', 1);

            Console.WriteLine(pos);


            Console.ReadLine();
        }
    }
}