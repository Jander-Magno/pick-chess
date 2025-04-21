namespace pick_chess.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtyMoves { get; protected set; }
        public Board bor { get; protected set; }

        public Piece(Board bor, Color color)
        {
            this.position = null;
            this.bor = bor;
            this.color = color;
            this.qtyMoves = 0;
        }

        public void incrementQtyMoves()
        {
            qtyMoves++;
        }
        public void decrementQtyMoves()
        {
            qtyMoves--;
        }

        public bool havePossibleMoves()
        {
            bool[,] arr = possibleMoves();
            for (int i = 0; i < bor.lines; i++)
            {
                for (int j = 0; j < bor.columns; j++)
                {
                    if (arr[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleMove(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
