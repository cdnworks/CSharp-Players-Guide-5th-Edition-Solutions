namespace DuelingTraditions;


//abstract class for monsters so they may be put into a collection in the game handler logic
public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;

    public Monster(Location spawnLocation) => Location = spawnLocation;

    //use the Activate method to do what the monster is built to do to the player when they are in the same room.
    public abstract void Activate(FountainOfObjectsGame game);
}
