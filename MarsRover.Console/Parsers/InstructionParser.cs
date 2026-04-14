using System;
using System.Collections.Generic;
using System.Text;

using MarsRover.Console.Models;

namespace MarsRover.Console.Parsers;

public class InstructionParser
{
    public static List<Instruction> ParseInstruction(string input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input), "Input cannot be null");
        var cleanString = input.ToUpper().Replace(" ", "");
        return cleanString.Select(c => c switch
            {
                'R' => Instruction.R,
                'M' => Instruction.M,
                'L' => Instruction.L,
                _ => throw new ArgumentException($"Invalid instruction: {input}")
            }).ToList();
    }
}