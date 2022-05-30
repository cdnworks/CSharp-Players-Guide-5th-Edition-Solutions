namespace DuelingTraditions;


public class Amarok : Monster
{
    public Amarok(Location spawnLocation) : base(spawnLocation) { }

    //amaroks simply kill the player if they collide.
    public override void Activate(FountainOfObjectsGame game)
    {
        game.Player.KillPlayer("You were eaten by an Amarok!");
    }
}
