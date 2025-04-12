﻿using pick_chess.board;

namespace pick_chess.Chess
{
    internal class Rook : Piece
    {
        public Rook(Board bor, Color color) : base(bor, color)
        {

        }

        public override string ToString()
        {
            return "R";
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

            //ABOVE
            pos.setValues(position.line - 1, position.column);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //BELOW
            pos.setValues(position.line + 1, position.column);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            //RIGHT
            pos.setValues(position.line, position.column + 1);
            while (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
                if (bor.piece(pos) != null && bor.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //LEFT
            pos.setValues(position.line, position.column - 1);
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
