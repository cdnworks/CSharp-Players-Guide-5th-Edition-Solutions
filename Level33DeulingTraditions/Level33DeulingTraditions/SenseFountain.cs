namespace DuelingTraditions;


//Represents the player hearing the water of the fountain. The message changes depending on if the fountain is on or not.
public class SenseFountain : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.FountainRoom) return true;
        else return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        if (game.IsFountainOn) TextHelper.WriteLine(ConsoleColor.DarkCyan, "The sound of rushing water fills the room. The Fountain has been reactivated!!");
        else TextHelper.WriteLine(ConsoleColor.DarkCyan, "You hear the faint dripping of water. The Fountain is here!!");
    }
}
