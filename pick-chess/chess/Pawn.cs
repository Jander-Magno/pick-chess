using System;
using pick_chess.board;
using pick_chess.Chess;

namespace pick_chess.chess
{
    internal class Pawn : Piece
    {

        private Match match;
        public Pawn(Board bor, Color color, Match match) : base(bor, color)
        {
            this.match = match;
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

                //#SpecialPlay En Passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (bor.positionValid(left) && existEnemy(left) && bor.piece(left) == match.vulnerableEnPassant)
                    {
                        arr[left.line, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (bor.positionValid(right) && existEnemy(right) && bor.piece(right) == match.vulnerableEnPassant)
                    {
                        arr[right.line, right.column] = true;
                    }
                }

                //#SpecialPlay En Passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (bor.positionValid(left) && existEnemy(left) && bor.piece(left) == match.vulnerableEnPassant)
                    {
                        arr[left.line, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (bor.positionValid(right) && existEnemy(right) && bor.piece(right) == match.vulnerableEnPassant)
                    {
                        arr[right.line, right.column] = true;
                    }
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
