using System;
using SmallRPGGame.Environment;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Interfaces;
using SmallRPGGame.Player;

namespace SmallRPGGame.GameHandling
{
    public class GameRunner : IGameRunner
    {
        public GameRunner(IInputHandler inputHandler, IOutputHandler outputHandler)
        {
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
        }

        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;
        private WorldHandler _worldHandler;
        private Character _character;
        private World _currentWorld;
        private World _previousWorld;

        public void InitialiseGame()
        {
            _worldHandler = new WorldHandler(new Random());
            _character = new Character(new Inventory());

            _currentWorld = _worldHandler.GenerateWorld();
            
            _inputHandler.Start(this);
        }

        public void Action(GameAction action)
        {
            switch (action)
            {
                case GameAction.Forward:
                    _previousWorld = _currentWorld;
                    _currentWorld = _worldHandler.GenerateWorld();
                    break;
                case GameAction.Back:
                    SwitchWorlds();
                    break;
                case GameAction.Fight:
                    _currentWorld.Fight(_character);
                    break;
                case GameAction.Observe:
                    break;
            }
            _currentWorld.Observe(_outputHandler);
            _inputHandler.Next();
        }

        private void SwitchWorlds()
        {
            if (_previousWorld == null)
            {
                throw new NoWorldToMoveToException("There must be a previous world to move to");
            }
            var tempWorld = _currentWorld;
            _currentWorld = _previousWorld;
            _previousWorld = tempWorld;
        }
    }
}