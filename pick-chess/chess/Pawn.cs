using System;
using pick_chess.board;

namespace pick_chess.chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board bor, Color color) : base(bor, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool existEnemy(Position pos)
        {
            Piece p = bor.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return bor.piece(pos) != null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] arr = new bool[bor.lines, bor.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.line - 1, position.column);
                if (bor.positionValid(pos) && free(pos))
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line - 2, position.column);
                if (bor.positionValid(pos) && free(pos) && qtyMoves == 0)
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line - 1, position.column - 1);
                if (bor.positionValid(pos) && existEnemy(pos))
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line - 1, position.column + 1);
                if (bor.positionValid(pos) && existEnemy(pos))
                {
                    arr[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.line + 1, position.column);
                if (bor.positionValid(pos) && free(pos))
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line + 2, position.column);
                if (bor.positionValid(pos) && free(pos) && qtyMoves == 0)
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line + 1, position.column - 1);
                if (bor.positionValid(pos) && existEnemy(pos))
                {
                    arr[pos.line, pos.column] = true;
                }

                pos.setValues(position.line + 1, position.column + 1);
                if (bor.positionValid(pos) && existEnemy(pos))
                {
                    arr[pos.line, pos.column] = true;
                }
            }
            return arr;
        }
    }
}
