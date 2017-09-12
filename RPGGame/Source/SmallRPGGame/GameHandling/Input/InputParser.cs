using SmallRPGGame.GameHandling.Actions;

namespace SmallRPGGame.GameHandling.Input
{
    public class InputParser
    {
        public GameAction ParseUserInput(string userInput)
        {
            var userInputLower = userInput.ToLower();

            switch (userInputLower)
            {
                case "forward":
                    return GameAction.Forward;
                case "back":
                    return GameAction.Back;
                case "observe":
                    return GameAction.Observe;
                case "fight":
                    return GameAction.Fight;
                case "exit":
                    return GameAction.Exit;
                default:
                    return GameAction.Unknown;
            }
        }
    }
}