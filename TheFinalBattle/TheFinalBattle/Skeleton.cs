namespace FinalBattle;

// Skeleton class; meant to be used by the Monsters party.
// Skeletons have 5 max health
public class Skeleton : Character
{
    public Skeleton(BattleGame game) : base()
    {
        _game = game;
        Name = "SKELETON";
        MaxHealth = 5;
        CurrentHealth = 5;

        // list of Skeleton's available actions
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() },
            {"bone crunch", new BoneCrunchAttack() }
        };
    }
}

