using System;
using NSubstitute;
using SmallRPGGame.Console.Interfaces;
using SmallRPGGame.Environment;
using SmallRPGGame.Environment.Monsters;
using SmallRPGGame.GameHandling;
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
                                 "Now go kill some Monsters!\n";

            _outputHandler.Welcome();

            _mockedConsole.Received(1).Write(openingMessage);
        }

        [Fact]
        public void WhenNextActionIsCalled_TheNextActionQuestionIsPrintedToTheConsole()
        {
            var nextActionText = "What would you like to do next?: ";

            _outputHandler.NextAction();

            _mockedConsole.Received(1).Write(nextActionText);
        }

        [Fact]
        public void WhenObserveIsCalled_TheWorldObservationIsPrintedToTheConsole()
        {
            var worldObservation = "World Observation";
            var observeText = $"You are currently in: {worldObservation}\n";

            _outputHandler.Observe(worldObservation);

            _mockedConsole.Received(1).Write(observeText);
        }

        [Fact]
        public void WhenExitIsCalled_TheThanksForPlayingTextIsPrintedToTheConsole()
        {
            var nextActionText = "Thanks for playing!";

            _outputHandler.Exit();

            _mockedConsole.Received(1).Write(nextActionText);
        }
    }
}