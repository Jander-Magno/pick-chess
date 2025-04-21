using pick_chess.board;

namespace pick_chess.Chess
{
    internal class King : Piece
    {

        private Match match;
        public King(Board bor, Color color, Match match) : base(bor, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = bor.piece(pos);
            return p == null || p.color != color;
        }

        private bool testRookForCast(Position pos)
        {
            Piece p = bor.piece(pos);
            return p != null && p is Rook && p.color == color && p.qtyMoves == 0;
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

            // #SpecialPlay Castling
            if (qtyMoves == 0 && !match.check)
            {
                //#SpecialPlay Minor Castling
                Position posT1 = new Position(position.line, position.column + 3); 
                if (testRookForCast(posT1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (bor.piece(p1) == null && bor.piece(p2) == null)
                    {
                        arr[position.line, position.column + 2] = true;
                    }
                }

                //#SpecialPlay Great Castling
                Position posT2 = new Position(position.line, position.column - 4);
                if (testRookForCast(posT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (bor.piece(p1) == null && bor.piece(p2) == null && bor.piece(p3) == null) 
                    {
                        arr[position.line, position.column - 2] = true;
                    }
                }
            }
            return arr;
        }
    }
}
