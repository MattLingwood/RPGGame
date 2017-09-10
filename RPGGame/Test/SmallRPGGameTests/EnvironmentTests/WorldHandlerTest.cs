using System;
using Shouldly;
using SmallRPGGame.Environment;
using SmallRPGGame.Environment.Monsters;
using Xunit;

namespace SmallRPGGameTests.EnvironmentTests
{
    public class WorldHandlerTest
    {
        private readonly WorldHandler _worldHandler;

        public WorldHandlerTest()
        {
            _worldHandler = new WorldHandler(new Random());
        }

        [Fact]
        public void WhenANewWorldIsCreated_ANewMonsterIsPlacedInside()
        {
            var generatedWorld = _worldHandler.GenerateWorld();

            var monster = generatedWorld.GetMonster();
            monster.Name.ShouldBe(MonsterName.Chicken);
        }
    }
}