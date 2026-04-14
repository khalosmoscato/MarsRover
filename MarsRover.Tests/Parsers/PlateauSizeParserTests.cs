using MarsRover.Console.Models;
using MarsRover.Console.Parsers;
namespace MarsRover.Tests.Parsers;

public class PlateauSizeParserTests
{
    [TestCase("")]
    [TestCase(null!)]
    [TestCase("   ")]
    public void ParsePlateau_ShouldHandleEmptyAndNullInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PlateauSizeParser.ParsePlateau(input));
    }

    [TestCase("5,5")]
    [TestCase("5 Y")]
    [TestCase("X 5")]
    [TestCase("X Y")]
    [TestCase("5")]
    [TestCase("5 5 5")]
    public void ParsePlateau_ShouldHandleMalformedInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PlateauSizeParser.ParsePlateau(input));
    }

    [TestCase("-5 5")]
    [TestCase("0 0")]
    [TestCase("2147483648 5")] // int overflow: out of range number which exceeds the maximum value of a 32-bit integer (int.MaxValue)
    public void ParsePlateau_ShouldHandleOutOfBoundariesInputs_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => PlateauSizeParser.ParsePlateau(input));
    }

    [TestCase("5 5 ", 5, 5)]
    [TestCase(" 5 5", 5, 5)]
    [TestCase("5  5", 5, 5)]
    [TestCase("5 5", 5, 5)]
    public void ParsePlateau_ShouldHandleWhiteSpaces_WhenInputIncludesLeadingOrEndingOrMultipleWhiteSpaces(string input, int expectedX, int expectedY)
    {
        var expected = new PlateauSize(expectedX, expectedY);
        var result = PlateauSizeParser.ParsePlateau(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}