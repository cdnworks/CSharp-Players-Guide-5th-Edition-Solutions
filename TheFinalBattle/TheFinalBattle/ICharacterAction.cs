namespace FinalBattle;

// Interface for different types of commands a character can take, utilized by different characters.
// all actions should interract with the game, have a character perfoming the action, and a target character
public interface ICharacterAction
{
    //performs the command on the gamestate
    public void Execute(BattleGame game, Character source, Character target);
}

