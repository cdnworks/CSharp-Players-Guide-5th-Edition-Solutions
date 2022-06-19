namespace FinalBattle;

// This character action causes the character to do nothing, effectively skipping their turn.
public class SkipAction : ICharacterAction
{
    public void Execute(BattleGame game, Character source, Character target)
    {
        Console.WriteLine($"{source.Name} did NOTHING!");
    }
}

