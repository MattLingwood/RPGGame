using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Input;

namespace SmallRPGGame
{
    public class GameCoordinator
    {
        public GameCoordinator(GameRunner gameRunner, InputHandler inputHandler)
        {
            _gameRunner = gameRunner;
            _inputHandler = inputHandler;
        }

        private readonly GameRunner _gameRunner;
        private readonly InputHandler _inputHandler;

        public void Play()
        {
            var play = true;
            while (play)
            {
                var action = _inputHandler.Next();
                
                play = _gameRunner.Action(action);
            }
        }
    }
}