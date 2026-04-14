using MarsRover.Console.Models;
using MarsRover.Console.Parsers;
namespace MarsRover.Tests.Parsers;

public class PositionParserTests
{
    [TestCase("")]
    [TestCase(null!)]
    [TestCase("   ")]
    public void ParsePosition_ShouldHandleEmptyAndNullInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PositionParser.ParsePosition(input));
    }

    [TestCase("1,2,N")]
    [TestCase("1 N S")]
    [TestCase("N 1")]
    [TestCase("1 2 3 N")]
    [TestCase("1")]
    [TestCase("5 5 5")]
    public void ParsePosition_ShouldHandleMalformedInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PositionParser.ParsePosition(input));
    }

    [TestCase("-1 2 N")]
    [TestCase("0 0 Z")]
    [TestCase("2147483648 2 N")]
    public void ParsePosition_ShouldHandleOutOfBoundariesInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PositionParser.ParsePosition(input));
    }

    [TestCase("1 2 N ", 1, 2, CompassDirection.North)]
    [TestCase(" 1 2 N", 1, 2, CompassDirection.North)]
    [TestCase("1  2   N", 1, 2, CompassDirection.North)]
    [TestCase("1 2 N", 1, 2, CompassDirection.North)]
    public void ParsePosition_ShouldHandleWhiteSpaces_WhenInputIncludesLeadingOrEndingOrMultipleWhiteSpaces(string input, int expectedX, int expectedY, CompassDirection expectedFacingDirection)
    {
        var expected = new Position(expectedX, expectedY, expectedFacingDirection);
        var result = PositionParser.ParsePosition(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}