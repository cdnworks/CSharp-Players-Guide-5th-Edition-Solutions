namespace DuelingTraditions;

//the map is a grid of rooms (a 2 dimensional array of RoomTypes) The constructor should allow for entering custom dimensions
//and sets all rooms to empty by default upon construction
public class Map
{
    private RoomType[,] _map;
    public int Rows { get; }
    public int Columns { get; }

    public Map(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _map = new RoomType[rows, columns];

        //generate an empty map on construction
        for (int i = 0; i < _map.GetLength(0); i++)
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                _map[i, j] = RoomType.Empty;
            }
    }

    //checks the boundary of the map. Useful for preventing the user or other entities from moving outside of the map area.
    public bool IsInbounds(Location location)
    {
        if (location.Row < 0 || location.Column < 0) return false;
        if (location.Row >= _map.GetLength(0) || location.Column >= _map.GetLength(1)) return false;
        return true;
    }


    //checks adjacent (from position) tiles for the passed in room type. For sensing pit rooms or something else.
    public bool IsRoomAdjacent(RoomType roomType, Location location)
    {
        //is this the dreadded code smell?
        // I also dislike the 8 direction adjacent system and restricted it down to four (north, east, south and west) for better gameplay
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row - 1 , location.Column - 1)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row - 1 , location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row + 1 , location.Column - 1)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row + 1 , location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column + 1)) == roomType) return true;
        return false;
    }


    //allow custom placement for rooms, as well as building the map on construction
    //ideally, when the game is started, the program will place an entrance and an exit.
    public void SetRoomTypeAtLocation(Location location, RoomType roomType) => _map[location.Row, location.Column] = roomType;
    //retrieve the room type at the location, if it is in bounds. If it is out of bounds, return the OOB room type.
    public RoomType GetRoomTypeAtLocation(Location location) => IsInbounds(location) ? _map[location.Row, location.Column] : RoomType.OutOfBounds;


}


//Records and Enums
public record Location(int Row, int Column);

public enum RoomType { Entrance, FountainRoom, Empty, OutOfBounds, Pit }
public enum Direction { North, East, South, West };
