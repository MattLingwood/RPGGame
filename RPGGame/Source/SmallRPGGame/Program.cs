using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var outputHandler = new OutputHandler(new ConsoleWrapper());
            var inputHandler = new InputHandler(outputHandler);

            var gameRunner = new GameRunner(inputHandler);

            gameRunner.InitialiseGame();
        }
    }
}
