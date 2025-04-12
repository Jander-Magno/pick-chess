using System;
using System.Security.Cryptography.X509Certificates;

namespace pick_chess.board
{
    internal class BoardException : Exception
    {
            public BoardException(string msg) : base(msg)
            {

            } 
    }
}
