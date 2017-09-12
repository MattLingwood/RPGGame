using System;
using SmallRPGGame.Environment;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Input;
using SmallRPGGame.GameHandling.Interfaces;
using SmallRPGGame.Player;

namespace SmallRPGGame.GameHandling
{
    public class GameRunner : IGameRunner
    {
        public GameRunner(IOutputHandler outputHandler)
        {
            _outputHandler = outputHandler;

            _worldHandler = new WorldHandler(new Random());
            _character = new Character(new Inventory());

            _currentWorld = _worldHandler.GenerateWorld();
        }

        private readonly IOutputHandler _outputHandler;
        private readonly WorldHandler _worldHandler;
        private readonly Character _character;
        private World _currentWorld;
        private World _previousWorld;


        public bool Action(GameAction action)
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
                case GameAction.Exit:
                    _outputHandler.Exit();
                    return false;
            }
            _outputHandler.Observe(_currentWorld.Observe());
            ;

            return true;
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