using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.GameHandling.Input
{
    public class InputHandler : IInputHandler
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IConsole _consoleWrapper;
        private InputParser _inputParser;

        public InputHandler(IOutputHandler outputHandler, IConsole consoleWrapper)
        {
            _outputHandler = outputHandler;
            _consoleWrapper = consoleWrapper;
            _inputParser = new InputParser();
        }

        public GameAction Next()
        {
            _outputHandler.NextAction();

            var userInput = _consoleWrapper.ReadLine();
            var action = _inputParser.ParseUserInput(userInput);

            return action;
        }
    }
}