﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using pick_chess.board;

namespace pick_chess.Chess
{
    internal class PositionChess
    {
        public char column {  get; set; }
        public int line { get; set; }

        public PositionChess(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position toPosition()
        {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + line;
        }

    }
}
