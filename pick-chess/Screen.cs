using System.Collections.Generic;
using pick_chess.Chess;
using pick_chess.board;

namespace pick_chess.board
{
    internal class Screen
    {

        public static void printMatch(Match match)
        {
            Screen.printBoard(match.bor);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.turn);
            if (!match.finished)
            {
                Console.WriteLine("Waiting play: " + match.actualPlayer);
                if (match.check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match);
            }
        }

        public static void printCapturedPieces(Match match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        } 

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.WriteLine(x + " ");
            }
            Console.Write("]");
        }

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
                Console.Write("- ");
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
                Console.Write(" ");
            }
        }

    }
}
