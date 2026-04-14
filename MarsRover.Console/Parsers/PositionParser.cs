using System;
using System.Collections.Generic;
using System.Text;

using MarsRover.Console.Models;

namespace MarsRover.Console.Parsers;

public class PositionParser
{
    public static Position ParsePosition(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Input cannot be null or empty.");
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3) throw new ArgumentException($"Expected 3 inputs (2 for the coordinates and 1 for the direction), but found {parts.Length}.");
        if (!int.TryParse(parts[0], out int x) || (!int.TryParse(parts[1], out int y))) throw new ArgumentException("Coordinates must be 2 valid integers.");
        if (x < 0 || y < 0) throw new ArgumentException("Coordinates cannot be negative integers.");
        CompassDirection facingDirection = DirectionParser.ParseDirection(parts[2].ToUpper()[0]);
        // this is already handled in the TryParse line, but we could include it if we wanted a more specific error message for numbers exceeding the int.MaxValue
        // if (x > int.MaxValue || y > int.MaxValue) throw new ArgumentException("Coordinates exceeds the maximum value of a 32-bit integer.");
        return new Position(x, y, facingDirection);
    }
}