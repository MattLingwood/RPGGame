using SmallRPGGame.GameHandling;

namespace SmallRPGGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputHandler = new InputHandler();

            var gameRunner = new GameRunner(inputHandler);

            gameRunner.InitialiseGame();
        }
    }
}
