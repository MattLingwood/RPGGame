namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IInputHandler
    {
        void Next();
        void Start(IGameRunner gameRunner);
    }
}