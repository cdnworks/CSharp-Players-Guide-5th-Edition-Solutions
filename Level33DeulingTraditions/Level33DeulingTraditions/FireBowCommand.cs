namespace DuelingTraditions;


//lets the player fire an arrow in the chosen direction.
public class FireBowCommand : ICommand
{
    Direction Direction { get; }
    public FireBowCommand(Direction direction) => Direction = direction;

    public void Execute(FountainOfObjectsGame game)
    {
        //check if the player has arrows to fire
        //check if there is a monster in the adjacent tile in the specified direction.
        //if there is, kill it. If there isnt a monster there, let the player know nothing happened.
        //reduce the player's arrow count by 1.
        if (game.Player.ArrowCount == 0)
        {
            TextHelper.WriteLine(ConsoleColor.Red, "You have no arrows to fire!");
            return;
        }

        Location firedLocation = Direction switch
        {
            Direction.North => new Location(game.Player.Location.Row + 1, game.Player.Location.Column),
            Direction.South => new Location(game.Player.Location.Row - 1, game.Player.Location.Column),
            Direction.East => new Location(game.Player.Location.Row, game.Player.Location.Column + 1),
            Direction.West => new Location(game.Player.Location.Row, game.Player.Location.Column - 1)
        };

        bool didArrowHit = false;
        //check the monster collection to see if there's a monster in location the arrow was fired into
        foreach (Monster monster in game.Monsters)
        {
            if (monster.Location == firedLocation)
            {
                monster.IsAlive = false;
                didArrowHit = true;
            }
        }

        if (didArrowHit) TextHelper.WriteLine(ConsoleColor.Green, "Your arrow hit something in the distance!");
        else TextHelper.WriteLine(ConsoleColor.Red, "You hear the echo of your arrow clattering off the stone in the distance...");

        game.Player.ArrowCount--;

    }
}
