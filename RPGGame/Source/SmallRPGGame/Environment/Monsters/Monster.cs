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

        public bool Fight(Character character)
        {
            return character.Level.GetLevel() <= Level;
        }
    }
}