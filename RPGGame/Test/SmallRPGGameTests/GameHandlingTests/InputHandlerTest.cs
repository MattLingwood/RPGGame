using System;
using NSubstitute;
using Shouldly;
using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Exceptions;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
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
        public void WhenStartIsCalled_ParsesUserInput_AndPassesToGameRunner()
        {
            _mockedConsole.ReadLine().Returns("Forward");

            _inputHandler.Start(_mockedGameRunner);

            _mockedOutputHandler.Received(1).Welcome();
            _mockedOutputHandler.Received(1).NextAction();
            _mockedGameRunner.Received(1).Action(GameAction.Forward);
        }

        [Fact]
        public void WhenNextIsCalledBeforeStart_ThrowsUnstartedGameException()
        {
            var exception = Should.Throw<GameNotStartedException>(() => _inputHandler.Next());

            exception.Message.ShouldBe("Game has not been started yet");
        }
    }
}