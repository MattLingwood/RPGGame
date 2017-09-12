using SmallRPGGame.GameHandling.Actions;

namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IInputHandler
    {
        GameAction Next();
    }
}