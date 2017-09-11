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
                              "Now go kill some Monsters!";
            _consoleOutput.Write(welcomeText);
        }

        public void NextAction()
        {
            var nextActionText = "What would you like to do next?: ";

            _consoleOutput.Write(nextActionText);
        }

        public void Observe(string worldDescription)
        {
            var observeText = $"You are currently in: {worldDescription}";

            _consoleOutput.Write(observeText);
        }
    }
}