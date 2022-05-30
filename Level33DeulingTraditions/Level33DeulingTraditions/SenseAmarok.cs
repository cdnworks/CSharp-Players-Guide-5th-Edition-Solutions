namespace DuelingTraditions;


//represents the player smelling an Amarok
public class SenseAmarok : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        //cycle through the game's list of monsters, check for maelstroms, and check if they are alive. if they are, calculate adjacency 
        //then display the sense if the maelstrom is adjacent.
        foreach (Monster monster in game.Monsters)
        {
            if (monster is Amarok && monster.IsAlive)
            {
                //look to see if the monster is 1 space away by finding the difference in the two's positions
                int rowDifference = Math.Abs(game.Player.Location.Row - monster.Location.Row);
                int columnDifference = Math.Abs(game.Player.Location.Column - monster.Location.Column);
                if (rowDifference <= 1 && columnDifference <= 1) return true;
            }
        }
        return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.DarkRed, "You smell the rotten stench of an amarok nearby...");
    }
}
