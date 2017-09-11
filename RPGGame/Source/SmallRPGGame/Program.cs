using SmallRPGGame.Console;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Input;

namespace SmallRPGGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var consoleWrapper = new ConsoleWrapper();

            var outputHandler = new OutputHandler(consoleWrapper);
            var inputHandler = new InputHandler(outputHandler, consoleWrapper);
            var gameRunner = new GameRunner(inputHandler, outputHandler);

            gameRunner.InitialiseGame();
        }
    }
}
