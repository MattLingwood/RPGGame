using System;
using NSubstitute;
using Shouldly;
using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.Player;
using Xunit;

namespace SmallRPGGameTests.EnvironmentTests.MonstersTests
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

            var result = monster.Fight(character);

            result.Outcome.ShouldBeTrue();
            result.Experience.ShouldBe(10);
        }

        [Fact]
        public void WhenDescribeIsCalled_ADescriptionOfTheMonsterIsReturned()
        {
            var mockedRandom = Substitute.For<Random>();
            mockedRandom.Next(1, 10).Returns(1);
            var monster = new Monster(MonsterName.Chicken, mockedRandom);

            var description = monster.Describe();

            description.ShouldBe("a level 1 Chicken");
        }
    }
}