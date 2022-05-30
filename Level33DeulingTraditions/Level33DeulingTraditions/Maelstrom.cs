namespace DuelingTraditions;


//class for the Maelstrom monster, contains status about it and initializes it's location on construction
public class Maelstrom : Monster
{
    public Maelstrom(Location spawnLocation) : base(spawnLocation) { }

    //the maelstrom blows the player away and moves away. Clamp the positions if they will cause the monster or player to go OOB
    public override void Activate(FountainOfObjectsGame game)
    {
        //generate two new locations, one for the player and one for the maelstrom, and clamp them, and update their positions in the game.
        //the player moves 1 space north, two east; the maelstrom moves 1 space south, two west
        TextHelper.WriteLine(ConsoleColor.Red, "You have been swept away by the gale of a Maelstrom!!");
        game.Player.Location = ClampedLocation(new Location(game.Player.Location.Row + 1, game.Player.Location.Column + 2), game.Map);
        Location = ClampedLocation(new Location(Location.Row - 1, Location.Column - 2), game.Map);
    }

    //clamp the location based on the map size if neccessary
    private Location ClampedLocation(Location moveLocation, Map map)
    {
        int clampedRow = moveLocation.Row;
        int clampedColumn = moveLocation.Column;
        //check if the move location is in bounds, if not, clamp it to the nearest in bounds space.
        if (moveLocation.Row < 0) clampedRow = 0;
        if (moveLocation.Row >= map.Rows) clampedRow = map.Rows - 1;
        if (moveLocation.Column < 0) clampedColumn = 0;
        if (moveLocation.Column >= map.Columns) clampedColumn = map.Columns - 1;
        return new Location(clampedRow, clampedColumn);
    }

}
