using NSubstitute;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class OutputHandlerTest
    {
        private readonly OutputHandler _outputHandler;
        private readonly IConsole _mockedConsole;

        public OutputHandlerTest()
        {
            _mockedConsole = Substitute.For<IConsole>();
            _outputHandler = new OutputHandler(_mockedConsole);
        }

        [Fact]
        public void WhenWelcomeIsCalled_TheOpeningMessageIsPrintedToTheConsole()
        {
            var openingMessage = "Welcome to Fantasy Land\n" +
                                 "Now go kill some Monsters!";

            _outputHandler.Welcome();

            _mockedConsole.Received(1).Write(openingMessage);
        }
    }
}