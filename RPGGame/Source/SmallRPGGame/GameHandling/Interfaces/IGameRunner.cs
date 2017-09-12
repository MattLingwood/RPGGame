using SmallRPGGame.GameHandling.Actions;

namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IGameRunner
    {
        bool Action(GameAction action);
    }
}