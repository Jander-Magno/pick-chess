using System;
using pick_chess.board;
using pick_chess.Chess;

namespace pick_chess.Chess
{
    internal class Match
    {
        public Board bor { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
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

        public void realizePlay(Position origin, Position destiny)
        {
            executeMove(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) 
        { 
           if (bor.piece(pos) == null)
            {
                throw new BoardException("Does not exist any piece in this position");
            }
           if (actualPlayer != bor.piece(pos).color)
            {
                throw new BoardException("The selected piece isn´t yours!"); 
            }
           if (!bor.piece(pos).havePossibleMoves())
            {
                throw new BoardException("Does not exist possible moves for this origin piece! ");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!bor.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("invalid destiny position!");
            }
        }

        private void changePlayer()
        {
            if (actualPlayer == Color.White)
            {
                actualPlayer = Color.Black;
            }
            else
            {
                actualPlayer = Color.White;
            }
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
