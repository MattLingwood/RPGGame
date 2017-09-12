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

        public string Observe()
        {
            var monsterDescription = _monster == null ? "nothing" : _monster.Describe();
            var worldDescription = $"A world where there is {monsterDescription}";

            return worldDescription;
        }

        public bool Fight(Character character)
        {
            if (_monster != null && _monster.Fight(character))
            {
                _monster = null;
                return true;
            }
            return false;
        }
    }
}