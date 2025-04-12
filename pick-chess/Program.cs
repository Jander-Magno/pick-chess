using pick_chess.board;

namespace pick_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board bor = new Board(8, 8);

            Screen.printBoard(bor);

            Console.ReadLine();
        }
    }
}