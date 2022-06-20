namespace FinalBattle;


// This class is the Computer controlled player. It should end up having basic decision making (read: random decision making)
public class ComputerPlayer : IPlayer
{
    public (string command, Character target) SelectAction(BattleGame game, Character character)
    {
        //create a new random for decision making
        Random random = new Random();

        //get a reference to both parties in the game, for target selection
        Party enemyParty = game.GetEnemyPartyFor(character);
        Party friendlyParty = game.GetFriendlyPartyFor(character);

        //pre-generate targets at random
        Character randomEnemy = enemyParty.CharacterList[random.Next(enemyParty.CharacterList.Count)];
        Character randomAlly = friendlyParty.CharacterList[random.Next(friendlyParty.CharacterList.Count)];

        //get a list of the moves from the character, then issue one at random
        // the action will target based on how it's called in BattleGame
        // which is temporary, the target should aslo be selected in a sensible way later on
        List<string> commandList = new List<string>(character.CharacterActions.Keys);
        string command = commandList[random.Next(commandList.Count)];


        //after picking the command, trigger it on an appropriate target
        //self target skills
        if (command == "skip") return ("skip", character);

        //friendly target skills (including self)

        //enemy target skills
        if (command == "punch") return ("punch", randomEnemy);
        if (command == "bone crunch") return ("bone crunch", randomEnemy);
        if (command == "unraveling") return ("unraveling", randomEnemy);

        //else case
        return ("skip", character);
    }

}
