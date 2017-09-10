using NSubstitute;
using SmallRPGGame.GameHandling;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests
{
    public class InputHandlerTest
    {
        private readonly InputHandler _inputHandler;

        public InputHandlerTest()
        {
            _inputHandler = new InputHandler();
        }

        [Fact]
        public void WhenStartIsCalled_ThenNextInputAsAsked_AndActionedOnGameRuner()
        {
            var mockedGameRunner = Substitute.For<GameRunner>();

            _inputHandler.Start(mockedGameRunner);

            mockedGameRunner.Received(1).Action();
        }
    }
}