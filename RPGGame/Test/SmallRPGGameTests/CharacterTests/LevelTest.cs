using Shouldly;
using SmallRPGGame.Character;
using Xunit;

namespace SmallRPGGameTests.CharacterTests
{
    public class LevelTest
    {
        private readonly Level _level;

        public LevelTest()
        {
            _level = new Level();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(99, 1)]
        [InlineData(100, 2)]
        [InlineData(200, 3)]
        public void WhenCharacterEarnsGivenExperience_ReturnsExpectedLevel(int experienceIn, int expectedLevel)
        {
            _level.AddExperience(experienceIn);

            var level = _level.GetLevel();

            level.ShouldBe(expectedLevel);
        }
    }
}