using System.Collections.Generic;
using pick_chess.board;
using pick_chess.chess;
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
        public bool check { get; private set; }

        public Match()
        {
            bor = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captures = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMove(Position origin, Position destiny)
        {
            Piece p = bor.removePiece(origin);
            p.incrementQtyMoves();
            Piece capturedPiece = bor.removePiece(destiny);
            bor.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captures.Add(capturedPiece);
            }
            return capturedPiece;

            //#SpecialPlay Minor Castling 
            if (p is King && destiny.column == origin.column + 2)
            {
                Position originR = new Position(origin.line, origin.column + 3);
                Position destinyR = new Position(destiny.line, destiny.column + 1);
                Piece R = bor.removePiece(destinyR);
                R.decrementQtyMoves();
                bor.putPiece(R, originR);
            }

            //#SpecialPlay Great Castling 
            if (p is King && destiny.column == origin.column - 2)
            {
                Position originR = new Position(origin.line, origin.column + 4);
                Position destinyR = new Position(destiny.line, destiny.column - 1);
                Piece R = bor.removePiece(destinyR);
                R.decrementQtyMoves();
                bor.putPiece(R, destinyR);
            }
        }

        public void dontMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = bor.removePiece(destiny);
            p.decrementQtyMoves();
            if (capturedPiece != null)
            {
                bor.putPiece(capturedPiece, destiny);
                captures.Remove(capturedPiece);
            }
            bor.putPiece(p, origin);
        }

        public void realizePlay(Position origin, Position destiny)
        {
            Piece piece = executeMove(origin, destiny);

            if (inCheck(actualPlayer))
            {
                dontMove(origin, destiny, piece);
                throw new BoardException("You can not check yourself!");
            }

            if (inCheck(adversary(actualPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckmate(adversary(actualPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }

            turn++;
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
            if (!bor.piece(origin).possibleMove(destiny))
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

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in inGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool inCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no king of color" + color + "on board!");
            }

            foreach (Piece x in inGamePieces(adversary(color)))
            {
                bool[,] arr = x.possibleMoves();
                if (arr[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color)
        {
            if (!inCheck(color))
            {
                return false;
            }
            foreach (Piece x in inGamePieces(color))
            {
                bool[,] arr = x.possibleMoves();
                for (int i = 0; i<bor.lines; i++)
                {
                    for (int j = 0; j<bor.columns; j++)
                    {
                        if (arr[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMove(x.position, destiny);
                            bool testCheck = inCheck(color);
                            dontMove(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            putNewPiece('a', 1, new Rook(bor, Color.White));
            putNewPiece('h', 1, new Rook(bor, Color.White));
            putNewPiece('b', 1, new Knight(bor, Color.White));
            putNewPiece('g', 1, new Knight(bor, Color.White));
            putNewPiece('c', 1, new Bishop(bor, Color.White));
            putNewPiece('f', 1, new Bishop(bor, Color.White));
            putNewPiece('e', 1, new King(bor, Color.White, this));
            putNewPiece('d', 1, new Queen(bor, Color.White));
            putNewPiece('a', 2, new Pawn(bor, Color.White));
            putNewPiece('h', 2, new Pawn(bor, Color.White));
            putNewPiece('b', 2, new Pawn(bor, Color.White));
            putNewPiece('g', 2, new Pawn(bor, Color.White));
            putNewPiece('c', 2, new Pawn(bor, Color.White));
            putNewPiece('f', 2, new Pawn(bor, Color.White));
            putNewPiece('e', 2, new Pawn(bor, Color.White));
            putNewPiece('d', 2, new Pawn(bor, Color.White));

            putNewPiece('a', 8, new Rook(bor, Color.Black));
            putNewPiece('h', 8, new Rook(bor, Color.Black));
            putNewPiece('b', 8, new Knight(bor, Color.Black));
            putNewPiece('g', 8, new Knight(bor, Color.Black));
            putNewPiece('c', 8, new Bishop(bor, Color.Black));
            putNewPiece('f', 8, new Bishop(bor, Color.Black));
            putNewPiece('e', 8, new King(bor, Color.Black, this));
            putNewPiece('d', 8, new Queen(bor, Color.Black));;
            putNewPiece('a', 7, new Pawn(bor, Color.Black));
            putNewPiece('h', 7, new Pawn(bor, Color.Black));
            putNewPiece('b', 7, new Pawn(bor, Color.Black));
            putNewPiece('g', 7, new Pawn(bor, Color.Black));
            putNewPiece('c', 7, new Pawn(bor, Color.Black));
            putNewPiece('f', 7, new Pawn(bor, Color.Black));
            putNewPiece('e', 7, new Pawn(bor, Color.Black));
            putNewPiece('d', 7, new Pawn(bor, Color.Black));
        }
    }
}
