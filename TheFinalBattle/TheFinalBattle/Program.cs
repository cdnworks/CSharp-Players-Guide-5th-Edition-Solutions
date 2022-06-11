/* Objectives: 
 * The game needs to be able to represent characters with a name and able to take a turn.
 * 
 * The game should be able to have skeleton characters with the name SKELETON
 * 
 * the game should be able to represent a party with a collection of characters.
 * 
 * The game should be able to run a battle composed of two parties.
 * Heroes and Monsters. A battle needs to run a series of rounds where each character in each party (heroes first) can take a turn.
 * 
 * Before a character takes their turn, the game should report to the user whose turn it is.
 * For example, "It is SKELETON's turn"
 * 
 * The only action the game needs to support at this point is the action of doing nothing. (Skipping a turn)
 * This action is done by displaying text about doing nothing, resting or skipping a turn in the console window.
 * For example, "SKELETON did NOTHING."
 * 
 * The game must run a battle with a single skeleton in both the hero and the monster party. At this point,
 * the two skeletons should do nothing repeatedly. The game might look like the following
 * ``` It is SKELETON's turn...
 * ``` SKELETON did NOTHING.
 * ```
 * ``` IT is SKELETON's turn...
 * ``` SKELETON did NOTHING.
 * 
 * OPTIONAL: Put a blank line between each character's turn to differentiate one turn from another.
 * 
 * OPTIONAL: At this point, the game will run automatically. Consider adding a Thread.Sleep(500);
 * to slow the game down enough to allow the user to see what is happening over time.
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
        _heroes.CharacterList.Add(new Skeleton(this));
        
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




// Abstract class for defining characters. Characters will have a Name, a reference to the gamestate and some Actions it can do that effect the game
// (thereby effecting other characters in the game)
public abstract class Character
{
    public string Name { get; set; }
    public BattleGame _game;
    //collection of character actions, utilizing a keyword associated with the action
    public Dictionary<string, ICharacterAction> CharacterActions { get; set; }

    // DoAction contains a list of commands a derived character class should 'know' how to do, then does the action when selected.
    public abstract void DoAction(string? command);
}


// SKELETON character
public class Skeleton : Character
{

    public Skeleton(BattleGame game) : base()
    {
        _game = game;
        Name = "SKELETON";

        // create list of actions a skeleton can do
        CharacterActions = new Dictionary<string, ICharacterAction>()
        {
            {"skip", new SkipAction() }

        };


    }

    public override void DoAction(string? command)
    {
        // null check and check if the action is not in the command dictionary
        // if the command is bad, skip turn
        if(command == null || CharacterActions.ContainsKey(command) == false )
        {
            SkipAction skipTurn = new SkipAction();
            skipTurn.Execute(_game, this);
        }



        // otherwise, do skeleton things
        ICharacterAction action = CharacterActions[command];
        action.Execute(_game, this);
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
