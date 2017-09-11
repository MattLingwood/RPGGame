using System;
using NSubstitute;
using SmallRPGGame.Environment;
using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.EnvironmentTests
{
    public class WorldHandlerTest
    {
        private readonly WorldHandler _worldHandler;
        private readonly Random _mockedLevelGenerator;
        private readonly IOutputHandler _mockedOutputHandler;

        public WorldHandlerTest()
        {
            _mockedLevelGenerator = Substitute.For<Random>();
            _mockedOutputHandler = Substitute.For<IOutputHandler>();
            _worldHandler = new WorldHandler(_mockedLevelGenerator);
        }

        [Theory]
        [InlineData(0, 3, "Chicken")]
        [InlineData(1, 2, "Pig")]
        [InlineData(2, 10, "Cow")]
        [InlineData(3, 7, "Bird")]
        [InlineData(4, 6, "Duck")]
        public void WhenANewWorldIsCreated_ANewRandomMonsterIsPlacedInside_WithARandomLevel(int animal, int level, string expectedMonster)
        {
            var countOfMonsterNames = Enum.GetNames(typeof(MonsterName)).Length;
            _mockedLevelGenerator.Next(countOfMonsterNames).Returns(animal);
            _mockedLevelGenerator.Next(1, 10).Returns(level);
            var generatedWorld = _worldHandler.GenerateWorld();

            generatedWorld.Observe(_mockedOutputHandler);

            _mockedOutputHandler.Received(1).Observe($"A world where there is a level {level} {expectedMonster}");
        }
    }
}