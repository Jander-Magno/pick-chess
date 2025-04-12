namespace pick_chess.board
{
    internal class Piece
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

    }
}
