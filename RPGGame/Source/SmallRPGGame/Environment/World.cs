using SmallRPGGame.Environment.Monsters;

namespace SmallRPGGame.Environment
{
    public class World
    {
        private readonly Monster _monster;

        public World(Monster monster)
        {
            _monster = monster;
        }

        public Monster GetMonster()
        {
            return _monster;
        }
    }
}