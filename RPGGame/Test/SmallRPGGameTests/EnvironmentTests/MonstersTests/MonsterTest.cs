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
            var character = new Character(new Inventory());
            mockedRandom.Next(1, 10).Returns(1);
            var monster = new Monster(MonsterName.Chicken, mockedRandom);
            

            var result = monster.Fight(character);

            result.ShouldBeTrue();
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