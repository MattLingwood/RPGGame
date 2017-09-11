using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.GameHandling
{
    public class InputHandler : IInputHandler
    {
        private IGameRunner _currentGame;
        private IOutputHandler _outputHandler;

        public InputHandler(IOutputHandler outputHandler)
        {
            _outputHandler = outputHandler;
        }

        public void Next()
        {
            _currentGame.Action();
        }

        public void Start(IGameRunner gameRunner)
        {
            _currentGame = gameRunner;
            _outputHandler.Welcome();
            Next();
        }
    }
}