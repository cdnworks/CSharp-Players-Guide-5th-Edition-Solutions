namespace FinalBattle;

// Interface for different types of commands a character can take, utilized by different characters.
public interface ICharacterAction
{
    //performs the command on the gamestate
    public void Execute(BattleGame game, Character target);
}

