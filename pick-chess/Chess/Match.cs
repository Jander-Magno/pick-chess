using System;
using pick_chess.board;

namespace pick_chess.Chess
{
    internal class Match
    {
        public Board bor { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool finished { get; private set; }

        public Match()
        {
            bor = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            finished = false;
            putPiece();
        }

        public void executeMove(Position origin, Position destiny)
        {
            Piece p = bor.removePiece(origin);
            p.incrementQtyMoves();
            Piece capturedPiece = bor.removePiece(destiny);
            bor.putPiece(p, destiny);
        }

        private void putPiece()
        {
            bor.putPiece(new Rook(bor, Color.White), new PositionChess('c', 1).toPosition());
            bor.putPiece(new Rook(bor, Color.White), new PositionChess('c', 2).toPosition());
            bor.putPiece(new Rook(bor, Color.White), new PositionChess('d', 2).toPosition());
            bor.putPiece(new Rook(bor, Color.White), new PositionChess('e', 2).toPosition());
            bor.putPiece(new Rook(bor, Color.White), new PositionChess('e', 1).toPosition());
            bor.putPiece(new King(bor, Color.White), new PositionChess('d', 1).toPosition());

            bor.putPiece(new Rook(bor, Color.Black), new PositionChess('c', 7).toPosition());
            bor.putPiece(new Rook(bor, Color.Black), new PositionChess('c', 8).toPosition());
            bor.putPiece(new Rook(bor, Color.Black), new PositionChess('d', 7).toPosition());
            bor.putPiece(new Rook(bor, Color.Black), new PositionChess('e', 7).toPosition());
            bor.putPiece(new Rook(bor, Color.Black), new PositionChess('e', 8).toPosition());
            bor.putPiece(new King(bor, Color.Black), new PositionChess('d', 8).toPosition());



        }
    }
}
