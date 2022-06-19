namespace FinalBattle;


// This is the main game handler class. It is responsible for executing or managing different game state effecting 
// methods and objects. It should end up tracking the game's win and lose conditions, user input and running results
public class BattleGame
{
    private Party _heroes;
    private Party _monsters;

    public BattleGame()
    {

        _heroes = new Party(new ComputerPlayer());
        _heroes.CharacterList.Add(new TrueProgrammer(this));
        
        _monsters = new Party(new ComputerPlayer());
        _monsters.CharacterList.Add(new Skeleton(this));
    }




    public void RunGame()
    {
        while(!IsOver())
        {
            foreach (Party party in new[] { _heroes, _monsters })
            {
                foreach (Character character in party.CharacterList)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    Thread.Sleep(500);
                    // this will just issue a sleep command for now
                    // Player.SelectAction returns a valid string 'command' to the DoAction method in Character
                    // which should handle the rest of the action process
                    // This provides the benefit of being able to randomly (or selectively) issue a legal command from the character's action dictionary
                    // for computer controlled Players, and input handling for player characters so they dont issue illegal commands

                    //SelectAction returns a tuple so we need to deconstruct it to use it
                    var selectedAction = party.Player.SelectAction(this, character);
                    var actionString = selectedAction.command;
                    var actionTarget = selectedAction.target;

                    character.DoAction(actionString, actionTarget);


                    //check if a party has been defeated, if it has, end the game
                    if (IsOver()) break;


                    


                }

                if (IsOver()) break;
            }
        }

        //The game ended, roll credits
        if (_heroes.CharacterList.Count > 0) Console.WriteLine("The Uncoded One's forces have been defeated, you win!");
        else Console.WriteLine("The Uncoded One has defeated you, a thousand clock cycles of darkness will shroud the lands. \nGame Over.");




    }



    // Utility methods

    // checks if a party has been defeated (meaning no member is alive/present), signaling the game is over
    public bool IsOver() => _heroes.CharacterList.Count == 0 || _monsters.CharacterList.Count == 0;

    //gets the party based on the current character's relation to it i.e. a skeleton's enemy party is the hero party, and it's party is the monster party
    public Party GetEnemyPartyFor(Character character) => _heroes.CharacterList.Contains(character) ? _monsters : _heroes;
    public Party GetFriendlyPartyFor(Character character) => _heroes.CharacterList.Contains(character) ? _heroes : _monsters;

}

