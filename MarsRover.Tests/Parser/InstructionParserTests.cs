using MarsRover.Console.Models;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class InstructionParserTests
{
    [Test]
    public void ParseInstruction_ShouldReturnEmptyList_WhenPassedWhiteSpace()
    {
        string input = "";
        var result = InstructionParser.ParseInstruction(input);
        var expected = new List<Instruction>();
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        InstructionParser.ParseInstruction(null!)
        );
    }

    [Test]
    public void ParseInstruction_ShouldReturnListOfInstructions_WhenGivenValidInput()
    {
        string input = "RML";

        var expected = new List<Instruction>
        {
            Instruction.R,
            Instruction.M,
            Instruction.L
        };

        var result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("LMR", 3)]
    [TestCase("MMMMM", 5)]
    [TestCase("", 0)]
    public void ParseInstruction_ShouldReturnCorrectCount_WhenValidInputProvided(string input, int expectedCount)
    {
        var result = InstructionParser.ParseInstruction(input);
        Assert.That(result.Count, Is.EqualTo(expectedCount));
    }

    [Test]
    public void ParseInstruction_ShouldMaintainCorrectOrder()
    {
        var result = InstructionParser.ParseInstruction("MRL");

        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(Instruction.M));
            Assert.That(result[1], Is.EqualTo(Instruction.R));
            Assert.That(result[2], Is.EqualTo(Instruction.L));
        });
    }

    [TestCase("l", Instruction.L)]
    [TestCase("m", Instruction.M)]
    [TestCase("r", Instruction.R)]
    public void ParseInstruction_ShouldHandleLowerCaseInput(string input, Instruction expected)
    {
        var result = InstructionParser.ParseInstruction(input);
        Assert.That(result[0], Is.EqualTo(expected), $"Lower cases such as '{input}' are handled correctly");
    }

    [Test]
    public void ParseInstruction_ShouldIgnoreWhiteSpaces_WhenGivenStringWithAMixOfCharsAndWhiteSpaces()
    {
        var result = InstructionParser.ParseInstruction("R R L");
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(Instruction.R));
            Assert.That(result[1], Is.EqualTo(Instruction.R));
            Assert.That(result[2], Is.EqualTo(Instruction.L));
        });
    }
}