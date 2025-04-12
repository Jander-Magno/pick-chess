namespace pick_chess.board
{
    internal class Screen
    {
        public static void printBoard(Board bor)
        {
            for (int i = 0; i<bor.lines; i++)
            {
                for (int j = 0; j < bor.columns; j++)
                {
                    if (bor.piece(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(bor.piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
