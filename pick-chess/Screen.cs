using System;
using pick_chess.Chess;
using pick_chess.board;

namespace pick_chess.board
{
    internal class Screen
    {
        public static void printBoard(Board bor)
        {
            for (int i = 0; i<bor.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < bor.columns; j++)
                {
                   printPiece(bor.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board bor, bool[,] possibleMoves)
        {

            ConsoleColor originalBackGround = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < bor.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < bor.columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    } 
                    else
                    {
                        Console.BackgroundColor = originalBackGround;
                    }
                    printPiece(bor.piece(i, j));
                    Console.BackgroundColor = originalBackGround;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackGround;
        }

        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.WriteLine("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.WriteLine(" ");
            }
        }

    }
}
