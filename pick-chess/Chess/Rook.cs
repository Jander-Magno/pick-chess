using pick_chess.board;

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
    }
}
