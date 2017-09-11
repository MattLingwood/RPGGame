using SmallRPGGame.GameHandling.Actions;

namespace SmallRPGGame.GameHandling
{
    public class InputParser
    {
        public GameAction ParseUserInput(string userInput)
        {
            var userInputLower = userInput.ToLower();
            return userInputLower.Equals("forward") ? GameAction.Forward : GameAction.Unknown;
        }
    }
}