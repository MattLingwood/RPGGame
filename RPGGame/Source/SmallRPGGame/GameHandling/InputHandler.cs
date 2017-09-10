namespace SmallRPGGame.GameHandling
{
    public class InputHandler
    {
        private GameRunner _currentGame;

        public void Next()
        {
            _currentGame.Action();
        }

        public void Start(GameRunner gameRunner)
        {
            _currentGame = gameRunner;

            Next();
        }
    }
}