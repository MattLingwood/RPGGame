using NSubstitute;
using SmallRPGGame.GameHandling;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class GameRunnerTest
    {

        [Fact]
        public void WhenTheUserStartsTheGame_GameRunnerSetsUpTheEnvironment()
        {
            var mockedInputHandler = Substitute.For<InputHandler>();
            var gameRunner = new GameRunner(mockedInputHandler);

            gameRunner.InitialiseGame();

            mockedInputHandler.Received(1).Start(gameRunner);
        }
    }
}