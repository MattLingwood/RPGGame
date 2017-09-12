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
        private readonly GameRunner _gameRunner;
        private readonly IOutputHandler _mockedOutputHandler;

        public GameRunnerTest()
        {
            _mockedOutputHandler = Substitute.For<IOutputHandler>();
            _gameRunner = new GameRunner(_mockedOutputHandler);
        }

        [Fact]
        public void WhenTheUserTriesToMoveForward_AndTheyHaventMovedWorldsYet_TheyAreUnableToMoveAndMustReinputTheirChoice()
        {
            var capturedException = Should.Throw<NoWorldToMoveToException>(() =>_gameRunner.Action(GameAction.Back));

            capturedException.Message.ShouldBe("There must be a previous world to move to");
        }

        [Theory]
        [InlineData(GameAction.Fight)]
        [InlineData(GameAction.Observe)]
        [InlineData(GameAction.Forward)]
        public void WhenTheUserMovesWorld_TheWorldIsAutomaticallyObserved(GameAction givenAction)
        {
            _gameRunner.Action(givenAction);
            
            _mockedOutputHandler.Received(1).Observe(Arg.Is<string>(x => x.StartsWith("A world where there is")));
        }
    }
}