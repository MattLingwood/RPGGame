using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.GameHandling.Input
{
    public class InputHandler : IInputHandler
    {
        private IGameRunner _currentGame;
        private readonly IOutputHandler _outputHandler;
        private readonly IConsole _consoleWrapper;
        private InputParser _inputParser;

        public InputHandler(IOutputHandler outputHandler, IConsole consoleWrapper)
        {
            _outputHandler = outputHandler;
            _consoleWrapper = consoleWrapper;
            _inputParser = new InputParser();
        }

        public void Next()
        {
            if (_currentGame == null)
            {
                throw new GameNotStartedException("Game has not been started yet");
            }
            _outputHandler.NextAction();

            var userInput = _consoleWrapper.ReadLine();
            var action = _inputParser.ParseUserInput(userInput);

            _currentGame.Action(action);
        }

        public void Start(IGameRunner gameRunner)
        {
            _currentGame = gameRunner;
            _outputHandler.Welcome();
            Next();
        }
    }
}