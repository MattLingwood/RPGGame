﻿using Shouldly;
using SmallRPGGame.GameHandling.Actions;
using SmallRPGGame.GameHandling.Input;
using Xunit;

namespace SmallRPGGameTests.GameHandlingTests.Input
{
    public class InputParserTest
    {
        [Theory]
        [InlineData("Forward", GameAction.Forward)]
        [InlineData("FORWARD", GameAction.Forward)]
        [InlineData("forward", GameAction.Forward)]
        [InlineData("Trash", GameAction.Unknown)]
        public void WhenParsingGivenString_ReturnsExpectedGameAction(string givenString, GameAction expectedGameAction)
        {
            var inputParser = new InputParser();

            var returnedGameAction = inputParser.ParseUserInput(givenString);

            returnedGameAction.ShouldBe(expectedGameAction);
        }

    }
}