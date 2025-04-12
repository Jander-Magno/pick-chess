using pick_chess.board;

namespace pick_chess.Chess
{
    internal class King : Piece
    {
        public King(Board bor, Color color) : base(bor, color)
        {

        }

        public override string ToString()
        {
            return "K";
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

            //Above
            pos.setValues(position.line - 1, position.column);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //NE
            pos.setValues(position.line, position.column + 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //RIGHT
            pos.setValues(position.line, position.column + 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //SE
            pos.setValues(position.line - 1, position.column + 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //BELOW
            pos.setValues(position.line + 1, position.column);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //SW
            pos.setValues(position.line + 1, position.column - 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //LEFT
            pos.setValues(position.line, position.column - 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }

            //NW
            pos.setValues(position.line - 1, position.column - 1);
            if (bor.positionValid(pos) && canMove(pos))
            {
                arr[pos.line, pos.column] = true;
            }
            return arr;
        }
    }
}
