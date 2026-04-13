using System;
using System.Collections.Generic;
using System.Text;

using MarsRover.Console.Models;

namespace MarsRover.Console.Parsers;

public class InstructionParser
{
    public static List<Instruction> ParseInstruction(string s)
    {
        if (s == null) throw new ArgumentNullException(nameof(s), "Input cannot be null");
        var normalisedString = s.ToUpper().Replace(" ", "");
        return normalisedString.Select(c => c switch
            {
                'R' => Instruction.R,
                'M' => Instruction.M,
                'L' => Instruction.L,
                _ => throw new ArgumentException($"Invalid instruction: {s}")
            }).ToList();
    }
}