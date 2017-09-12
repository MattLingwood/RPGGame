using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Actions;
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

        private GameRunner _gameRunner;
        private InputHandler _inputHandler;

        public void Play()
        {
            var play = true;
            while (play)
            {
                var action = _inputHandler.Next();
                if (action == GameAction.Exit)
                {
                    play = false;
                }

                _gameRunner.Action(action);
            }
        }
    }
}