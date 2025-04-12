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
                    if (bor.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece)
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
        }

    }
}
