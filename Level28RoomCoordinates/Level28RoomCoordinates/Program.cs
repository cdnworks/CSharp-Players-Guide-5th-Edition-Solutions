//this class contains a struct that can represent a 'room' with cartesian coordinates.
//locations are represented by a row and a column.
//
// Objectives
// Create a Coordinate struct that can represent a room coordinate with a row and column
//ensure Coordinate is immutable
// make a method to determine if one coordinate is adjacent to another (differing only by a single row or column
// write a main method that creates a few coordinates and determines if they are adjacent to each other


Coordinate c1 = new Coordinate(0, 1);
Coordinate c2 = new Coordinate(0, 2);
Coordinate c3 = new Coordinate(1, 2);
Coordinate c4 = new Coordinate(5, 5);

Console.WriteLine(Coordinate.IsAdjacent(c1,c2));
Console.WriteLine(Coordinate.IsAdjacent(c2,c3));
Console.WriteLine(Coordinate.IsAdjacent(c4,c1));


public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool IsAdjacent(Coordinate c1, Coordinate c2)
    {
        //adjacency is achieved if the coordinates exist within 1 point of eachother.
        //but also not the same point.
        // e.g. (0,0) is adjacent to (1,0),(-1,0),(0,1) and (0,-1), but obviously not (0,0)
        return ((c1.Row == c2.Row && c1.Column == c2.Column + 1) 
            || (c1.Row == c2.Row && c1.Column == c2.Column - 1) 
            || (c1.Column == c2.Column && c1.Row == c2.Row + 1) 
            || (c1.Column == c2.Column && c1.Row == c2.Row - 1));
    }

}