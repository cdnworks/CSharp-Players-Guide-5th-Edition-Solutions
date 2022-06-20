namespace FinalBattle;


// This is the main game handler class. It is responsible for executing or managing different game state effecting 
// methods and objects. It's primary function is to manage and track all the in game characters, manage turns, allow the players
// to issue commands and determine if a party has won or lost the battle.
public class BattleGame
{
    private Party _heroes;
    private Party _monsters;

    private bool _isGameOver = false;

    // while there is a generic _monsters party, that will hold the party of monsters being currently fought by the hero party
    // these two parties hold the individual monster parties, which swap out when the game loop breaks, selected from the monsterParties list
    private Party monsterParty1;
    private Party monsterParty2;
    private Party monsterParty3;

    private List<Party> monsterParties = new List<Party>();

    public BattleGame()
    {

        _heroes = new Party(new HumanPlayer());
        _heroes.CharacterList.Add(new TrueProgrammer(this));
        
        monsterParty1 = new Party(new ComputerPlayer());
        monsterParty1.CharacterList.Add(new Skeleton(this));

        monsterParty2 = new Party(new ComputerPlayer());
        monsterParty2.CharacterList.Add(new Skeleton(this));
        monsterParty2.CharacterList.Add(new Skeleton(this));

        monsterParty3 = new Party(new ComputerPlayer());
        monsterParty3.CharacterList.Add(new UncodedOne(this));

        monsterParties.Add(monsterParty1);
        monsterParties.Add(monsterParty2);
        monsterParties.Add(monsterParty3);



        //set the first party to fight
        _monsters = monsterParties[0];
    }




    public void RunGame()
    {

        //run until the game is over (e.g. all monster parties are defeated, or the hero party is defeated)
        while(!_isGameOver)
        {
            foreach (Party party in new[] { _heroes, _monsters })
            {
                foreach (Character character in party.CharacterList)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    Thread.Sleep(500);
                    // Player.SelectAction returns a valid string 'command', and an appropriate target to the DoAction method in Character

                    //SelectAction returns a tuple so we need to deconstruct it to use it
                    var selectedAction = party.Player.SelectAction(this, character);
                    var actionString = selectedAction.command;
                    var actionTarget = selectedAction.target;

                    character.DoAction(actionString, actionTarget);


                    // Win/Loss state checks

                    if (_heroes.CharacterList.Count == 0)
                    {
                        //heroes lost, end the game.
                        _isGameOver = true;
                        break;
                    }


                    if (_monsters.CharacterList.Count == 0)
                    {
                        // if the monsterParties count is 2 or more, that means theres a party left to fight,
                        // remove the first party, doing so will shift all other monster parties forward 1 index
                        // assign _monsters to the new monsterParties[0]
                        // the battle continues as normal
                        if (monsterParties.Count > 1)
                        {
                            monsterParties.RemoveAt(0);
                            _monsters = monsterParties[0];
                        }
                        
                        // no extra monster parties to fight, the game is over!
                        else
                        {
                            _isGameOver = true;
                            break;
                        }
                    }

                }

                if (_isGameOver) break;
            }
        }

        //The game ended, roll credits
        if (_heroes.CharacterList.Count > 0) Console.WriteLine("The Uncoded One's forces have been defeated, you win!");
        else Console.WriteLine("The Uncoded One has defeated you, a thousand clock cycles of darkness will shroud the lands. \nGame Over.");




    }



    // Utility methods


    //gets the party based on the current character's relation to it i.e. a skeleton's enemy party is the hero party, and it's party is the monster party
    public Party GetEnemyPartyFor(Character character) => _heroes.CharacterList.Contains(character) ? _monsters : _heroes;
    public Party GetFriendlyPartyFor(Character character) => _heroes.CharacterList.Contains(character) ? _heroes : _monsters;

}

