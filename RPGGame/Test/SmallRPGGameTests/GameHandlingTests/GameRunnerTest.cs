using NSubstitute;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class GameRunnerTest
    {

        [Fact]
        public void WhenTheUserStartsTheGame_GameRunnerSetsUpTheEnvironment()
        {
            var mockedInputHandler = Substitute.For<IInputHandler>();
            var gameRunner = new GameRunner(mockedInputHandler);

            gameRunner.InitialiseGame();

            mockedInputHandler.Received(1).Start(gameRunner);
        }
    }
}