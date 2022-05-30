namespace DuelingTraditions;


//player class contains status about the player and initializes the location of the player on construction
public class Player
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; }

    public int ArrowCount { get; set; } = 5;

    //if the player dies, hold a string explaining what killed them. Initially, this string is empty.
    public string CauseOfDeath { get; set; }

    public Player(Location startLocation)
    {
        //upon construction, the player starts at a specified starting location
        Location = startLocation;
        IsAlive = true;
        CauseOfDeath = "";
    }

    //method for killing the player and setting the cause of death in the event the player dies
    public void KillPlayer(string causeOfDeath)
    {
        IsAlive = false;
        CauseOfDeath = causeOfDeath;
    }
}
