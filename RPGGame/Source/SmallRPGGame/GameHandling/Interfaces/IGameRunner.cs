using SmallRPGGame.GameHandling.Actions;

namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IGameRunner
    {
        void Action(GameAction action);
        void InitialiseGame();
    }
}