using System;
using SmallRPGGame.Environment;
using SmallRPGGame.GameHandling.Interfaces;
using SmallRPGGame.Player;

namespace SmallRPGGame.GameHandling
{
    public class GameRunner : IGameRunner
    {
        public GameRunner(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private WorldHandler _worldHandler;
        private Character _character;
        private World _currentWorld;
        private readonly IInputHandler _inputHandler;

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