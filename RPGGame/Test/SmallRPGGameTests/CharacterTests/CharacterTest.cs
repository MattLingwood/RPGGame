using Shouldly;
using SmallRPGGame.Character;
using Xunit;

namespace SmallRPGGameTests.CharacterTests
{
    public class CharacterTest
    {
        private Character _character;

        public CharacterTest()
        {
            _character = new Character();
        }

        [Fact]
        public void WhenTheCharacterIsNew_GetLevelReturnsOne()
        {
            var level = _character.GetLevel();

            level.ShouldBe(1);
        }
    }
}