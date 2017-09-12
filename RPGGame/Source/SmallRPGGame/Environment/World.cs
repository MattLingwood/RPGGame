using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.GameHandling.Interfaces;
using SmallRPGGame.Player;

namespace SmallRPGGame.Environment
{
    public class World
    {
        public World(Monster monster)
        {
            _monster = monster;
        }

        private Monster _monster;

        public void Observe(IOutputHandler output)
        {
            var monsterDescription = _monster == null ? "nothing" : _monster.Describe();
            var worldDescription = $"A world where there is {monsterDescription}";

            output.Observe(worldDescription);
        }

        public void Fight(Character character)
        {
            if (_monster != null && _monster.Fight(character))
            {
                _monster = null;
            }
        }
    }
}