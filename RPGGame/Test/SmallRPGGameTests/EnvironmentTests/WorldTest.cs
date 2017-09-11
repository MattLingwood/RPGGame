using System;
using NSubstitute;
using Shouldly;
using SmallRPGGame.Environment;
using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.GameHandling.Interfaces;
using SmallRPGGame.Player;
using Xunit;

namespace SmallRPGGameTests.EnvironmentTests
{
    public class WorldTest
    {
        [Fact]
        public void WhenTheWorldIsObserved_ADescriptionOfTheWorldIsReturned()
        {
            var mockedRandom = Substitute.For<Random>();
            var mockedOutputHandler = Substitute.For<IOutputHandler>();
            mockedRandom.Next(1, 10).Returns(3);
            var monster = new Monster(MonsterName.Chicken, mockedRandom);
            var world = new World(monster);

            world.Observe(mockedOutputHandler);

            mockedOutputHandler.Received(1).Observe("A world where there is a level 3 Chicken");
        }

        [Fact]
        public void WhenTheCharacterFightsInTheWorld_IfTheCharacterIsStrongerThanTheMonster_ReturnTrue()
        {
            var mockedRandom = Substitute.For<Random>();
            mockedRandom.Next(1, 10).Returns(1);
            var monster = new Monster(MonsterName.Chicken, mockedRandom);
            var world = new World(monster);
            var character = new Character(new Inventory());

            var results = world.Fight(character);

            results.Outcome.ShouldBeTrue();
        }
    }
}