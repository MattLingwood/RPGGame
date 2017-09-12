using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.GameHandling
{
    public class OutputHandler : IOutputHandler
    {
        private readonly IConsole _consoleOutput;

        public OutputHandler(IConsole consoleOutput)
        {
            _consoleOutput = consoleOutput;
        }

        public void Welcome()
        {
            var welcomeText = "Welcome to Fantasy Land\n" +
                              "Now go kill some Monsters!\n";
            _consoleOutput.Write(welcomeText);
        }

        public void Exit()
        {
            var exitText = "Thanks for playing!";

            _consoleOutput.Write(exitText);
        }

        public void NextAction()
        {
            var nextActionText = "What would you like to do next?: ";

            _consoleOutput.Write(nextActionText);
        }

        public void Observe(string worldDescription)
        {
            var observeText = $"You are currently in: {worldDescription}\n";

            _consoleOutput.Write(observeText);
        }
    }
}