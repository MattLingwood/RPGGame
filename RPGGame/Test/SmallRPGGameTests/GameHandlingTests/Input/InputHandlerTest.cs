using NSubstitute;
using Shouldly;
using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Input;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests.Input
{
    public class InputHandlerTest
    {
        private readonly InputHandler _inputHandler;
        private readonly IOutputHandler _mockedOutputHandler;
        private readonly IGameRunner _mockedGameRunner;
        private readonly IConsole _mockedConsole;

        public InputHandlerTest()
        {
            _mockedOutputHandler = Substitute.For<IOutputHandler>();
            _mockedGameRunner = Substitute.For<IGameRunner>();
            _mockedConsole = Substitute.For<IConsole>();
            _inputHandler = new InputHandler(_mockedOutputHandler, _mockedConsole);
        }

        [Fact]
        public void WhenStartIsCalled_CallsWelcomeText_AndThenCallsNextAction()
        {
            _inputHandler.Start(_mockedGameRunner);

            _mockedOutputHandler.Received(1).Welcome();
            _mockedOutputHandler.Received(1).NextAction();
        }

        [Fact]
        public void WhenNextIsCalledAfterStart_ParsesUserInput_AndPassesToGameRunner()
        {
            _mockedConsole.ReadLine().Returns("Forward", "Back");
            _inputHandler.Start(_mockedGameRunner);

            _inputHandler.Next();

            _mockedOutputHandler.Received(1).Welcome();
            _mockedOutputHandler.Received(2).NextAction();
            _mockedGameRunner.Received(1).Action(GameAction.Forward);
            _mockedGameRunner.Received(1).Action(GameAction.Back);
        }

        [Fact]
        public void WhenNextIsCalledBeforeStart_ThrowsUnstartedGameException()
        {
            var exception = Should.Throw<GameNotStartedException>(() => _inputHandler.Next());

            exception.Message.ShouldBe("Game has not been started yet");
        }
    }
}