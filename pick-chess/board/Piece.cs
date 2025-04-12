namespace pick_chess.board
{
    internal class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtyMoves { get; protected set; }
        public Board bor { get; protected set; }

        public Piece(Position position, Board bor, Color color)
        {
            this.position = position;
            this.bor = bor;
            this.color = color;
            this.qtyMoves = 0;
        }
    }
}
