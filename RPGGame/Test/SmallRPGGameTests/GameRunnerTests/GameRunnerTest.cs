using SmallRPGGame.GameRunner;
using Xunit;

namespace SmallRPGGameTests.GameRunnerTests
{
    public class GameRunnerTest
    {
        private readonly GameRunner _gameRunner;

        public GameRunnerTest()
        {
            _gameRunner = new GameRunner();
        }

        [Fact]
        public void WhenTheUserStartsTheGame_GameRunnerSetsUpTheEnvironment()
        {
            _gameRunner.InitialiseGame();
        }
    }
}