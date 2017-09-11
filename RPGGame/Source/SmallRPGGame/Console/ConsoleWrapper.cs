using SmallRPGGame.Console.Interfaces;

namespace SmallRPGGame.Console
{
    public class ConsoleWrapper : IConsole
    {
        public void Write(string text)
        {
            System.Console.Write(text + "\n\n");
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}