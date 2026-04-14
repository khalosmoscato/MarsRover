using System;
using System.Collections.Generic;
using System.Text;

using MarsRover.Console.Models;

namespace MarsRover.Console.Parsers;

public class PlateauSizeParser
{
    public static PlateauSize ParsePlateau(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Input cannot be null or empty.");
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2) throw new ArgumentException($"Expected 2 coordinates, but found {parts.Length}.");
        if (!int.TryParse(parts[0], out int x) || (!int.TryParse(parts[1], out int y))) throw new ArgumentException("Coordinates must be 2 valid integers.");
        if (x <= 0 || y <= 0) throw new ArgumentException("Coordinates cannot be negative integers");
        if (x > int.MaxValue || y > int.MaxValue) throw new ArgumentException("Coordinates exceeds the maximum value of a 32-bit integer.");
        return new PlateauSize(x, y);
    }
}