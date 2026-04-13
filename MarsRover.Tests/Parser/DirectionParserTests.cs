using MarsRover.Console.Models;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class DirectionParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase('N', CompassDirection.North)]
    [TestCase('E', CompassDirection.East)]
    [TestCase('S', CompassDirection.South)]
    [TestCase('W', CompassDirection.West)]
    public void ParseDirection_ShouldReturnCorrectDirection_WhenGivenValidChar(char input, CompassDirection expected)
    {
        var result = DirectionParser.ParseDirection(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseDirection_ShouldThrowAnError_WhenGivenInvalidInput()
    {
        var invalidInput = 'A';

        Assert.Throws<ArgumentException>(() =>
        DirectionParser.ParseDirection(invalidInput), "The parser should throw an ArgumentException when an invalid input is provided");
    }
}