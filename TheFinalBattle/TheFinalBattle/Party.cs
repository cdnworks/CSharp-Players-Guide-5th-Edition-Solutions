namespace FinalBattle;

// Party class. Contains the controlling player and a list of characters
public class Party
{
    public IPlayer Player { get; }
    public List<Character> CharacterList { get; } = new List<Character>();

    public Party (IPlayer player)
    {
        Player = player;
    }

}

