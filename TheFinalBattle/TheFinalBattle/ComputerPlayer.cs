namespace FinalBattle;


// This class is the Computer controlled player. It should end up having basic decision making (read: random decision making)
// for now, it just skips turns
public class ComputerPlayer : IPlayer
{
    public string SelectAction(BattleGame game, Character character)
    {
        //get a list of the moves from the character, then issue one at random
        // the action will target based on how it's called in BattleGame
        // which is temporary, the target should aslo be selected in a sensible way later on
        List<string> commandList = new List<string>(character.CharacterActions.Keys);

        Random random = new Random();
        return commandList[random.Next(commandList.Count)];


    }
}
