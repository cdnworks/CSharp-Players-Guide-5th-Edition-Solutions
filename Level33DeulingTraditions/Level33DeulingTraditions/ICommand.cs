namespace DuelingTraditions;


//interface for player commands
public interface ICommand
{
    //performs the command and executes it on the gamestate
    public void Execute(FountainOfObjectsGame game);
}
