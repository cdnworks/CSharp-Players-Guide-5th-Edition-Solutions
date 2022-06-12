/* Objectives: 
 * Add a True Programmer character
 * The character will be named by user input
 * 
 */


// MAIN
BattleGame game = new BattleGame();
game.RunGame();


// TYPE DEFS


// This is the main game handler class. It is responsible for executing or managing different game state effecting 
// methods and objects. It should end up tracking the game's win and lose conditions, user input and running results
public class BattleGame
{
    private Party _heroes;
    private Party _monsters;

    public BattleGame()
    {

        _heroes = new Party();
        _heroes.CharacterList.Add(new TrueProgrammer(this));
        
        _monsters = new Party();
        _monsters.CharacterList.Add(new Skeleton(this));
    }




    public void RunGame()
    {
        while(true)
        {
            foreach (Party party in new[] { _heroes, _monsters })
            {
                foreach (Character character in party.CharacterList)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    Thread.Sleep(500);
                    character.DoAction("skip");
                }
            }
        }
    }

}




// Party class. Contains a list of characters
public class Party
{
    public List<Character> CharacterList { get; } = new List<Character>();
}




// Abstract class for defining characters. Characters will have a Name, a reference to the gamestate and a list of Actions it can do
// (thereby effecting change in other characters in the game)
public abstract class Character
{
    public string Name { get; set; }
    public BattleGame _game;

    //collection of character actions, utilizing a keyword associated with the action
    public Dictionary<string, ICharacterAction> CharacterActions { get; set; }

    // DoAction fires off the action with the associated keyword argument
    public void DoAction(string? command)
    {
        // null check and check if the action is not in the command dictionary
        // if the command is bad, skip turn
        if (command == null || CharacterActions.ContainsKey(command) == false)
        {
            SkipAction skipTurn = new SkipAction();
            skipTurn.Execute(_game, this);
        }

        // otherwise, do the selected action
        ICharacterAction action = CharacterActions[command];
        action.Execute(_game, this);
    }
}


// Character Classes
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


        // list of TrueProgrammer's available actions
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() }
        };
    }
}









// Interface for different types of commands a character can take, utilized by different characters.
public interface ICharacterAction
{
    //performs the command on the gamestate
    public void Execute(BattleGame game, Character target);
}


// This action causes the character to do nothing, effectively skipping their turn.
public class SkipAction : ICharacterAction
{
    public void Execute(BattleGame game, Character self)
    {
        Console.WriteLine($"{self.Name} did NOTHING!");
    }
}

