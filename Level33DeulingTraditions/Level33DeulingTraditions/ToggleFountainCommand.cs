namespace DuelingTraditions;


//changes the on or off state of the fountain of objects
public class ToggleFountainCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        //check if the player is in the fountain room
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.FountainRoom)
        {
            //change fountain state
            if (game.IsFountainOn) game.IsFountainOn = false;
            else game.IsFountainOn = true;
        }
        else TextHelper.WriteLine(ConsoleColor.Red, "The fountain isn't here, there was no effect.");
    }
}
