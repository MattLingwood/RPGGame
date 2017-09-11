using SmallRPGGame.GameHandling;

namespace SmallRPGGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var outputHandler = new OutputHandler();
            var inputHandler = new InputHandler(outputHandler);

            var gameRunner = new GameRunner(inputHandler);

            gameRunner.InitialiseGame();
        }
    }
}
