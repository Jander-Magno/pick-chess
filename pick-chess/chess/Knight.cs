using System;
using pick_chess.board;

namespace pick_chess.chess
{
    internal class Knight : Piece
    {
        public Knight(Board bor, Color color) : base(bor, color)
        {

        }

        public override string ToString()
        {
            return "N";
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

            pos.setValues(position.line - 1, position.column - 2);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 2, position.column - 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 2, position.column + 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 1, position.column + 2);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 1, position.column + 2);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 2, position.column + 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 2, position.column - 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 1, position.column - 2);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }
            return arr;
        }
    }
}
