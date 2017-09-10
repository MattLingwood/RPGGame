using System;
using SmallRPGGame.World.Monsters;

namespace SmallRPGGame.World
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