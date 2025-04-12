﻿using System;
using pick_chess.board;
using pick_chess.Chess;

namespace pick_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Board bor = new Board(8, 8);

                bor.putPiece(new Rook(bor, Color.Black), new Position(0, 0));
                bor.putPiece(new Rook(bor, Color.Black), new Position(1, 3));
                bor.putPiece(new King(bor, Color.Black), new Position(0, 2));

                bor.putPiece(new Rook(bor, Color.White), new Position(3, 5));

                Screen.printBoard(bor);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}