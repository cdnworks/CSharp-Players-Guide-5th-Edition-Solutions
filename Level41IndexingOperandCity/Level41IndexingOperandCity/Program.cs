/* This program is an extension of my level 41 implementation of Operand City
 * Here I add the ability to index BlockCoordinate by a number
 * 
 * 
 * Objectives:
 * Using the given records and enums as a starting point:
 * 
 * Add an addition operator to BlockCoordinate that takes a BlockCoordinate and a BlockOffset as arguments
 * and produces a new BlockCoordinate that refers to the one you would arrive at by starting at the original coordinate
 * and moving by the offset. That is, if we started at (4,3), and had an offset of (2,0) we should end up at (6,3)
 * 
 * Add another addition operator to BlockCoordinate that takes a BlockCoordinate and a Direction as arguments and produces a new BlockCoordinate
 * that is a block in the direction we indicated. i.e. if we start at (4,3), and went east, we should end up at (4,4)
 * 
 * write code to ensure both operators work correctly.
 * 
 * 
 * Extended Objectives:
 * 
 * Add a get only indexer to BlockCoordinate to acces items by an index:
 * Index 0 is the row, and Index 1 is the column
 * 
 * 
 */

// Main

BlockCoordinate testBlockCoordinate = new BlockCoordinate(0, 0);

BlockOffset testOffset = new BlockOffset(1, 1);


//try adding offsets
BlockCoordinate testBlockCoordinate2 = testBlockCoordinate + testOffset;

BlockCoordinate testBlockCoordinate3 = testOffset + testBlockCoordinate;


//try the directional overload
BlockCoordinate testBlockCoordinate4 = testBlockCoordinate + Direction.North;

// The below wont work as we didn't define an overload for this orientation!
//BlockCoordinate testBlockCoordinate5 = Direction.South + testBlockCoordinate;



Console.WriteLine($"Base coordinate: ({testBlockCoordinate.Row}, {testBlockCoordinate.Column})");

Console.WriteLine($"Adding offset:   ({testBlockCoordinate2.Row}, {testBlockCoordinate2.Column})");

Console.WriteLine($"Adding offset:   ({testBlockCoordinate3.Row}, {testBlockCoordinate3.Column})");

Console.WriteLine($"Directional:     ({testBlockCoordinate4.Row}, {testBlockCoordinate4.Column})");



Console.WriteLine($"Accessing Base coordinate's row by indexer: {testBlockCoordinate[0]}");




// Records and Enums

public record BlockCoordinate(int Row, int Column)
{
    //I make two different overloads for BlockCoordinate and BlockOffset to supply operations for both orientations
    //Addition is Commutative afterall.
    public static BlockCoordinate operator +(BlockCoordinate bc, BlockOffset bo) =>
        new BlockCoordinate(bc.Row + bo.RowOffset, bc.Column + bo.ColumnOffset);
    public static BlockCoordinate operator +(BlockOffset bo, BlockCoordinate bc) =>
        new BlockCoordinate(bc.Row + bo.RowOffset, bc.Column + bo.ColumnOffset);


    //adding a direction to the block coordinate is a little more complicated as it includes four cardinal directions to work out of.
    //Going North subtracts 1 from row, going South adds 1
    //Going West subtracts 1 from column, going East adds 1
    //I could copy this code to make it add the other way, but Im being lazy.
    public static BlockCoordinate operator +(BlockCoordinate bc, Direction direction)
    {
        if (direction == Direction.North) return new BlockCoordinate(bc.Row - 1, bc.Column);
        if (direction == Direction.South) return new BlockCoordinate(bc.Row + 1, bc.Column);
        if (direction == Direction.East) return new BlockCoordinate(bc.Row, bc.Column + 1);
        if (direction == Direction.West) return new BlockCoordinate(bc.Row, bc.Column - 1);

        //theres probably a smarter default but here we are, we need a default to make all return paths valid
        else return new BlockCoordinate(bc.Row, bc.Column);
    }

    //Indexer
    public int this[int index]
    {
        get
        {
            if (index == 0) return this.Row;
            else return this.Column;
        }
    }
};
public record BlockOffset(int RowOffset, int ColumnOffset);

public enum Direction { North, East, South, West }