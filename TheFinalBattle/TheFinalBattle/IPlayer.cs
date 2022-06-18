namespace FinalBattle;

// Interface for players. The player should have some information before deciding actions.
// take in the game and character information (namely its more important that the player knows what
// actions the current character knows how to do
public interface IPlayer
{
    string SelectAction(BattleGame game, Character character);
}