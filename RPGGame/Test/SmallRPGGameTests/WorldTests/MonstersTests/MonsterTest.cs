using System;
using NSubstitute;
using Shouldly;
using SmallRPGGame.Player;
using SmallRPGGame.World.Monsters;
using Xunit;

namespace SmallRPGGameTests.WorldTests.MonstersTests
{
    public class MonsterTest
    {
        [Fact]
        public void WhenANewMonsterIsCreated_ARandomLevelIsAssignedToIt()
        {
            var mockedRandom = Substitute.For<Random>();
            mockedRandom.Next(1, 10).Returns(5);

            var monster = new Monster(MonsterName.Chicken, mockedRandom);
            
            monster.Level.ShouldBe(5);
        }

        [Fact]
        public void WhenFightingAMonster_IfCharactersLevelIsHigher_MonsterIsBeaten()
        {
            var mockedRandom = Substitute.For<Random>();
            mockedRandom.Next(1, 10).Returns(1);
            var monster = new Monster(MonsterName.Chicken, mockedRandom);
            var character = new Character(new Inventory());

            var outcome = monster.Fight(character);

            outcome.ShouldBeTrue();
        }
    }
}