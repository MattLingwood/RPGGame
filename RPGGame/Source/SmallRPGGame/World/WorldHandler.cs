using System;
using SmallRPGGame.World.Monsters;

namespace SmallRPGGame.World
{
    public class WorldHandler
    {
        public World GenerateWorld()
        {
            var levelGenerator = new Random();
            var monster = new Monster(MonsterName.Chicken, levelGenerator);
            return new World(monster);
        }
    }
}