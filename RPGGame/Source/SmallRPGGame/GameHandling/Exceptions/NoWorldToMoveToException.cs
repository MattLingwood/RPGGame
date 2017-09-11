using System;

namespace SmallRPGGame.GameHandling.Exceptions
{
    public class NoWorldToMoveToException : Exception
    {
        public NoWorldToMoveToException(string message) : base (message)
        {
        }
    }
}