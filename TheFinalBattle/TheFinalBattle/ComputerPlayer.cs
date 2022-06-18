namespace FinalBattle;


// This class is the Computer controlled player. It should end up having basic decision making (read: random decision making)
// for now, it just skips turns
public class ComputerPlayer : IPlayer
{
    public string SelectAction(BattleGame game, Character character)
    {
        //this is just dummied out and will skip turns
        return "skip";
    }
}
