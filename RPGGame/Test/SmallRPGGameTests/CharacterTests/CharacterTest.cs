using NSubstitute;
using Shouldly;
using SmallRPGGame.Character;
using SmallRPGGame.Items;
using Xunit;

namespace SmallRPGGameTests.CharacterTests
{
    public class CharacterTest
    {
        private readonly Character _character;
        private readonly Inventory _mockedInventory;

        public CharacterTest()
        {
            _mockedInventory = NSubstitute.Substitute.For<Inventory>();
            _character = new Character(_mockedInventory);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(99, 1)]
        [InlineData(100, 2)]
        [InlineData(200, 3)]
        public void WhenCharacterEarnsGivenExperience_ReturnsExpectedLevel(int experienceIn, int expectedLevel)
        {
            _character.Level.AddExperience(experienceIn);

            var level = _character.Level.GetLevel();

            level.ShouldBe(expectedLevel);
        }

        [Fact]
        public void WhenCharacterEarnsMutlipleExperiences_LevelKeepsIncreasing()
        {
            _character.Level.AddExperience(60);
            var levelOne = _character.Level.GetLevel();

            _character.Level.AddExperience(60);
            var levelTwo = _character.Level.GetLevel();

            levelOne.ShouldBe(1);
            levelTwo.ShouldBe(2);
        }

        [Fact]
        public void WhenCharacterUsesAnItem_InventoryActionsTheUse()
        {
            _character.UseItem(Equipment.Spade);

            _mockedInventory.Received(1).UseItem(Equipment.Spade);
        }
    }
}