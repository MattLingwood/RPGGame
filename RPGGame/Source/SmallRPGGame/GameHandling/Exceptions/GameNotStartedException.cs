using System;

namespace SmallRPGGame.GameHandling.Exceptions
{
    public class GameNotStartedException : Exception
    {
        public GameNotStartedException(string message) : base(message)
        {
        }
    }
}