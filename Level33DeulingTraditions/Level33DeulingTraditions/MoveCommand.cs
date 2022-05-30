namespace DuelingTraditions;


//takes in a direction from the game state controller, FountainOfObjectsGame
// then applies a transform to the player's position 
public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction) => Direction = direction;

    //adjusts player location by 1 room depending on the user's selected direction.
    public void Execute(FountainOfObjectsGame game)
    {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            //this orientation places (0,0) in the south western corner of the grid.
            Direction.North => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1)
        };

        //check if the move is legal, if it is, move the player, if not, alert the player and dont move them
        if (game.Map.IsInbounds(newLocation)) game.Player.Location = newLocation;
        else TextHelper.WriteLine(ConsoleColor.Red, "There's a wall in that direction! Try going a different direction.");
    }
}
