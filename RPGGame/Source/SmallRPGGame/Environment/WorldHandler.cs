using System;
using SmallRPGGame.Environment.Monsters;

namespace SmallRPGGame.Environment
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
            var monsterNameIndex = _levelGenerator.Next(Enum.GetNames(typeof(MonsterName)).Length).ToString();
            var monsterName = (MonsterName) Enum.Parse(typeof(MonsterName), monsterNameIndex);
            var monster = new Monster(monsterName, _levelGenerator);
            return new World(monster);
        }
    }
}