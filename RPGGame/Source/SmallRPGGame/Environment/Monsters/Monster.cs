using System;
using SmallRPGGame.Player;

namespace SmallRPGGame.Environment.Monsters
{
    public class Monster
    {
        public Monster(MonsterName name, Random levelGenerator)
        {
            Name = name;
            Level = levelGenerator.Next(1, 10);
        }

        public MonsterName Name { get; }
        public int Level { get; }

        public FightOutcome Fight(Character character)
        {
            return new FightOutcome(character.Level.GetLevel() <= Level, Level * 10);
        }

        public string Describe()
        {
            return $"a level {Level} {Name.ToString()}";
        }
    }
}