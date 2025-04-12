using System;
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
                Match match = new Match();

                while (!match.finished)
                {
                    Console.Clear();
                    Screen.printBoard(match.bor);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readPositionChess().toPosition();
                    
                    match.executeMove(origin, destiny);
                }

                Screen.printBoard(match.bor);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}