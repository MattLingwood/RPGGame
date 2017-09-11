using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.GameHandling
{
    public class OutputHandler : IOutputHandler
    {
        private IConsole _consoleOutput;

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
    }
}