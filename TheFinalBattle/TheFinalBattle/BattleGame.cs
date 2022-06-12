namespace FinalBattle;


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

