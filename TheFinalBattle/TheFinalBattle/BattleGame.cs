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
        while(true)
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
                    character.DoAction(party.Player.SelectAction(this, character), character);
                }
            }
        }
    }



}

