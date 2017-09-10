using System;
using SmallRPGGame.World.Monsters;

namespace SmallRPGGame.World
{
    public class WorldHandler
    {
        private readonly Random _levelGenerator;

        public WorldHandler(Random levelGenerator)
        {
            _levelGenerator = levelGenerator;
        }

        public World GenerateWorld()
        {
            var monster = new Monster(MonsterName.Chicken, _levelGenerator);
            return new World(monster);
        }
    }
}