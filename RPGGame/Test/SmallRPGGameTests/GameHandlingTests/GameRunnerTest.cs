using NSubstitute;
using Shouldly;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class GameRunnerTest
    {
        private GameRunner _gameRunner;
        private IInputHandler _mockedInputHandler;

        public GameRunnerTest()
        {
            _mockedInputHandler = Substitute.For<IInputHandler>();
            _gameRunner = new GameRunner(_mockedInputHandler);

        }

        [Fact]
        public void WhenTheUserStartsTheGame_GameRunnerSetsUpTheEnvironment()
        {
            
            _gameRunner.InitialiseGame();

            _mockedInputHandler.Received(1).Start(_gameRunner);
        }

        [Fact]
        public void WhenTheUserTriesToMoveForward_AndTheyHaventMovedWorldsYet_TheyAreUnableToMoveAndMustReinputTheirChoice()
        {
            _gameRunner.InitialiseGame();

            var capturedException = Should.Throw<NoWorldToMoveToException>(() =>_gameRunner.Action(GameAction.Back));

            capturedException.Message.ShouldBe("There must be a previous world to move to");
        }
    }
}