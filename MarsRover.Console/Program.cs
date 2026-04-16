using MarsRover.Console.Parsers;

string plateau1 = "5 5";
string roverPosition = "1 2 N";

Console.WriteLine("--- Mars Rover Orchestrator Starting ---");

var plateauSize = PlateauSizeParser.ParsePlateau(plateau1);
var initialRoverPosition = PositionParser.ParsePosition(roverPosition);

Console.WriteLine(plateauSize);
Console.WriteLine(initialRoverPosition);