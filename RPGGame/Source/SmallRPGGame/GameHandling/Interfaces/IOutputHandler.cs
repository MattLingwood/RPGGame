namespace SmallRPGGame.GameHandling.Interfaces
{
    public interface IOutputHandler
    {
        void Welcome();
        void NextAction();
        void Observe(string worldDescription);
    }
}