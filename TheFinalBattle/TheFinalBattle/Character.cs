﻿namespace FinalBattle;

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
