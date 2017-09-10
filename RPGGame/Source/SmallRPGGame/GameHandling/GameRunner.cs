using System;
using SmallRPGGame.Environment;
using SmallRPGGame.Player;

namespace SmallRPGGame.GameHandling
{
    public class GameRunner
    {
        public GameRunner(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private WorldHandler _worldHandler;
        private Character _character;
        private World _currentWorld;
        private readonly InputHandler _inputHandler;

        public void InitialiseGame()
        {
            _worldHandler = new WorldHandler(new Random());
            _character = new Character(new Inventory());

            _currentWorld = _worldHandler.GenerateWorld();

            _inputHandler.Start(this);
        }

        public void Action()
        {
            _inputHandler.Next();
        }
    }
}