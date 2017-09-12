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
        private readonly IConsole _mockedConsole;

        public InputHandlerTest()
        {
            _mockedOutputHandler = Substitute.For<IOutputHandler>();
            _mockedConsole = Substitute.For<IConsole>();
            _inputHandler = new InputHandler(_mockedOutputHandler, _mockedConsole);
        }

        [Fact]
        public void WhenNextIsCalledAfterStart_ParsesUserInput_AndPassesToGameRunner()
        {
            _mockedConsole.ReadLine().Returns("Forward", "Back");

            var firstAction = _inputHandler.Next();
            var secondAction = _inputHandler.Next();

            firstAction.ShouldBe(GameAction.Forward);
            secondAction.ShouldBe(GameAction.Back);
        }
    }
}