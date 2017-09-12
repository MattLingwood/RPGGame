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
        public void WhenTheCharacterFightsInTheWorld_TheMonsterHandlesTheFight()
        {
            var mockedRandom = Substitute.For<Random>();
            mockedRandom.Next(1, 10).Returns(1);
            var mockedMonster = Substitute.For<Monster>(MonsterName.Chicken, mockedRandom);
            var world = new World(mockedMonster);
            var character = new Character(new Inventory());

            world.Fight(character);

            mockedMonster.Received(1).Fight(character);
        }

        [Fact]
        public void WhenTheCharacterFightsInTheWorld_IfTheMonsterDies_TheWorldShouldBeEmpty()
        {
            var mockedRandom = Substitute.For<Random>();
            var mockedOutputHandler = Substitute.For<IOutputHandler>();
            mockedRandom.Next(1, 10).Returns(1);
            var mockedMonster = new Monster(MonsterName.Chicken, mockedRandom);
            var world = new World(mockedMonster);
            var character = new Character(new Inventory());

            world.Fight(character);

            world.Observe(mockedOutputHandler);
            mockedOutputHandler.Received(1).Observe("A world where there is nothing");
        }

        [Fact]
        public void WhenTheCharacterTriesToFightAnEmptyWorld_NoExceptionsAreThrown()
        {
            var world = new World(null);
            var character = new Character(new Inventory());

            Should.NotThrow(() => world.Fight(character));
        }
    }
}