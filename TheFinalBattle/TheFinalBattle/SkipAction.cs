namespace FinalBattle;

// This character action causes the character to do nothing, effectively skipping their turn.
public class SkipAction : ICharacterAction
{
    public void Execute(BattleGame game, Character self)
    {
        Console.WriteLine($"{self.Name} did NOTHING!");
    }
}

