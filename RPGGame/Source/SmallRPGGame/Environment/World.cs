using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.GameHandling.Interfaces;

namespace SmallRPGGame.Environment
{
    public class World
    {
        public World(Monster monster)
        {
            _monster = monster;
        }

        private readonly Monster _monster;

        public Monster GetMonster()
        {
            return _monster;
        }

        public void Observe(IOutputHandler output)
        {
            var worldDescription = $"A world where this is a {_monster.Name.ToString()}";

            output.Observe(worldDescription);
        }
    }
}