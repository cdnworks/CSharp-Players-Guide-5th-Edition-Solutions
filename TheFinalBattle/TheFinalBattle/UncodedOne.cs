namespace FinalBattle;

// Skeleton class; meant to be used by the Monsters party.
// Skeletons have 5 max health
public class UncodedOne : Character
{
    public UncodedOne(BattleGame game) : base()
    {
        _game = game;
        Name = "THE UNCODED ONE";
        MaxHealth = 15;
        CurrentHealth = 15;

        // list of Skeleton's available actions
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() },
            {"unraveling", new UnravelingAttack() }
        };
    }
}

