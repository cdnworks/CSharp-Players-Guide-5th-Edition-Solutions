// See https://aka.ms/new-console-template for more information

//a deck of cards in the Realms of C# contains:
//four suits (colors): Red, Green, Blue, Yellow
//ranks of 1-10 with faces of $, %, ^ and &
//in total, there are 56 Cards in a deck

//this program contains a Card class that represents a card with it's color and rank.
//the class has properties that tell you if the card is a number or face card
//the main mehtod will create a card instance for the whole deck and display each.

//there are enumerations describing the card colors and card ranks.



//the problem states to display one copy of each card, but nothing about storing them as a deck so I will
//be overwriting the same variable with new cards as we iterate through a nested loop
//of Colors -> Ranks
Color[] colors = new Color[] {Color.Red, Color.Green, Color.Blue, Color.Yellow};
Rank[] ranks = new Rank[] { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Modulo, Rank.Hat, Rank.Ampersand };

foreach (Color color in colors)
{
    foreach (Rank rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {card.Rank} of {card.Color}, IsFaceCard: {card.IsFaceCard}");
    }
}





public class Card
{
    public Color Color { get; }
    public Rank Rank { get; }

    public Card (Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }

    public bool IsFaceCard
    {
        get
        {
            bool result = Rank switch
            {
                Rank.Dollar => true,
                Rank.Modulo => true,
                Rank.Hat => true,
                Rank.Ampersand => true,
                _ => false
            };
            return result;
        }
    }

}




//enumeration definitions
public enum Color { Red, Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Modulo, Hat, Ampersand}