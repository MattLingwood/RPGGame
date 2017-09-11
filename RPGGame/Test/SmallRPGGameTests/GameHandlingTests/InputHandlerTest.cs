using NSubstitute;
using SmallRPGGame.GameHandling;
using SmallRPGGame.GameHandling.Interfaces;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class InputHandlerTest
    {
        private readonly InputHandler _inputHandler;
        private readonly IOutputHandler _mockedOutputHandler;

        public InputHandlerTest()
        {
            _mockedOutputHandler = Substitute.For<IOutputHandler>();
            _inputHandler = new InputHandler(_mockedOutputHandler);
        }

        [Fact]
        public void WhenStartIsCalled_ThenNextInputAsAsked_AndActionedOnGameRuner()
        {
            var mockedGameRunner = Substitute.For<IGameRunner>();

            _inputHandler.Start(mockedGameRunner);

            _mockedOutputHandler.Received(1).Welcome();
            mockedGameRunner.Received(1).Action();
        }
    }
}