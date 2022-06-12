namespace FinalBattle;

// Skeleton class; meant to be used by the Monsters party.
public class Skeleton : Character
{
    public Skeleton(BattleGame game) : base()
    {
        _game = game;
        Name = "SKELETON";

        // list of Skeleton's available actions
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() }
        };
    }
}

