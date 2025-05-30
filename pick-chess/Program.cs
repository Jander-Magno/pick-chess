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
                Match match = new Match();

                while (!match.finished)
                {
                    try
                    {


                        Console.Clear();
                        Screen.printMatch(match);
                   

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possibleMoves = match.bor.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.printBoard(match.bor);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readPositionChess().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.realizePlay(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.printMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}