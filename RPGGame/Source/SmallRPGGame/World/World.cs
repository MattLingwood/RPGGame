using SmallRPGGame.World.Monsters;

namespace SmallRPGGame.World
{
    public class World
    {
        private readonly Monster _monster;

        public World()
        {
            _monster = new Monster(MonsterName.Chicken);
        }

        public Monster GetMonster()
        {
            return _monster;
        }
    }
}