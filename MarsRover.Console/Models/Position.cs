using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Console.Models;

public readonly record struct Position(int X, int Y, CompassDirection Facing);