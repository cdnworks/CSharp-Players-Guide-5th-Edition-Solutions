namespace DuelingTraditions;


//Represents the player seeing the light from the outside world via the entrance.
public class SenseEntrance : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance) return true;
        else return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.Yellow, "You see the soft light of the sun through the tunnel here. It is the cave entrance.");
    }
}
