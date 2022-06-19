namespace FinalBattle;

// This Character is intended to be the player's character
// upon creation (before the BattleGame is run) the player names the TrueProgrammer.
// The player has 25 health
public class TrueProgrammer : Character
{
    public TrueProgrammer(BattleGame game) : base()
    {
        _game = game;

        //Get & set the player's name for the TrueProgrammer
        Console.WriteLine("What is your name?");
        Name = Console.ReadLine();
        if (Name == null || Name == "") Name = "default mcdefaultface";
        Name = Name.ToUpper();

        //set health
        MaxHealth = 25;
        CurrentHealth = 25;


        // list of TrueProgrammer's available actions
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() },
            {"punch", new PunchAttack() }
        };
    }
}

