﻿using System;
using pick_chess.board;

namespace pick_chess.chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board bor, Color color) : base(bor, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = bor.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] arr = new bool[bor.lines, bor.columns];

            Position pos = new Position(0, 0);

            //NW
            pos.setValues(position.line - 1, position.column - 1);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //NE
            pos.setValues(position.line - 1, position.column + 1);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            //SW
            pos.setValues(position.line + 1, position.column - 1);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //SE
            pos.setValues(position.line + 1, position.column + 1);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            return arr;
        }
    }

}
