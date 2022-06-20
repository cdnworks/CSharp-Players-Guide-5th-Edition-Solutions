namespace FinalBattle;


// this is the controller for the user. It allows them to make appropriate commands based on the
// controlled character's available actions
public class HumanPlayer : IPlayer
{
    public (string command, Character target) SelectAction(BattleGame game, Character character)
    {
        Console.WriteLine("Enter one of the actions given below: ");
        //get and display a list of the commands the character knows
        foreach (string characterAction in character.CharacterActions.Keys)
        {
            Console.WriteLine(characterAction);
        }

        string? commandInput;
        Character targetInput;
        ICharacterAction actionFromDictionary;

        //collect a legal command
        while (true)
        {
            commandInput = Console.ReadLine();
            if (character.CharacterActions.ContainsKey(commandInput))
            {
                actionFromDictionary = character.CharacterActions[commandInput];
                break;
            };
        }

        //after picking the command, collect an appropriate target

        //self target skills
        if (commandInput == "skip") return ("skip", character);




        //friendly target skills (including self)




        //enemy target skills
        if (actionFromDictionary is AttackAction)
        {
            int targetNumber = 1;
            Console.WriteLine("Select a target: ");
            foreach(Character enemy in game.GetEnemyPartyFor(character).CharacterList)
            {
                Console.WriteLine($"{targetNumber}: {enemy.Name}");
                targetNumber++;
            }

            //collect a legal target
            while (true)
            {
                Console.WriteLine("Enter a number listed above: ");
                int inputNumber = Convert.ToInt32(Console.ReadLine());
                if (inputNumber <= game.GetEnemyPartyFor(character).CharacterList.Count || inputNumber >= 1)
                {
                    // since we listed and took in the targets by a more readable number (starting from 1, not 0)
                    // adjust the input number so it'll accurately reflect the index of the corresponding target
                    targetInput = game.GetEnemyPartyFor(character).CharacterList[inputNumber -1];
                    break;
                }
            }

            return (commandInput, targetInput);

        }






        //default return
        return ("skip", character);
    }

}