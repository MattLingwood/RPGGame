﻿using System;

namespace SmallRPGGame.World.Monsters
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

        public bool Fight(Character.Character character)
        {
            return character.Level.GetLevel() <= Level;
        }
    }
}