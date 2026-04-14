using System;
using System.Collections.Generic;
using System.Text;

using MarsRover.Console.Models;

namespace MarsRover.Console.Parsers;

public class DirectionParser
{
    public static CompassDirection ParseDirection(char c) => c switch
    {
        'N' => CompassDirection.North,
        'E' => CompassDirection.East,
        'S' => CompassDirection.South,
        'W' => CompassDirection.West,
        _ => throw new ArgumentException($"Invalid direction: {c}")
    };
}