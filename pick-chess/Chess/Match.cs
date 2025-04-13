using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captures;

        public Match()
        {
            bor = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captures = new HashSet<Piece>();
            putPieces();
        }

        public void executeMove(Position origin, Position destiny)
        {
            Piece p = bor.removePiece(origin);
            p.incrementQtyMoves();
            Piece capturedPiece = bor.removePiece(destiny);
            bor.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captures.Add(capturedPiece);
            }
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
                throw new BoardException("Invalid destiny position!");
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

        public HashSet<Piece> capturedPieces(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captures)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> inGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            bor.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Rook(bor, Color.White));
            putNewPiece('c', 2, new Rook(bor, Color.White));
            putNewPiece('d', 2, new Rook(bor, Color.White));
            putNewPiece('e', 2, new Rook(bor, Color.White));
            putNewPiece('e', 1, new Rook(bor, Color.White));
            putNewPiece('d', 1, new King(bor, Color.White));

            putNewPiece('c', 7, new Rook(bor, Color.White));
            putNewPiece('c', 8, new Rook(bor, Color.White));
            putNewPiece('d', 7, new Rook(bor, Color.White));
            putNewPiece('e', 7, new Rook(bor, Color.White));
            putNewPiece('e', 8, new Rook(bor, Color.White));
            putNewPiece('d', 8, new King(bor, Color.White));
        }

    }
}
