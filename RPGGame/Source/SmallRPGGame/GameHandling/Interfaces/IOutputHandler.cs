namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IOutputHandler
    {
        void Welcome();
        void Exit();
        void NextAction();
        void Observe(string worldDescription);
    }
}