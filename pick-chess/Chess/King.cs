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
    }
}
