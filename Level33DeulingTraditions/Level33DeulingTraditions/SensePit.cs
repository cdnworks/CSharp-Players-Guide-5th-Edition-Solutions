namespace DuelingTraditions;


//represents the player feeling a draft from a nearby pit.
public class SensePit : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        return game.Map.IsRoomAdjacent(RoomType.Pit, game.Player.Location);
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.DarkGray, "You feel a sudden draft around you, beware, there must be a deadly pit nearby...");
    }
}
