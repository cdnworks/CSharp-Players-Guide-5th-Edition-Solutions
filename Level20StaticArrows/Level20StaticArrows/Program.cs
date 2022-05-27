// See https://aka.ms/new-console-template for more information


//this program takes a user input for different types of arrows,
//their choices include the arrow head type, the fletching type and a length for the arrow shaft
//each type and length incurrs a different cost, and should be displayed to the user after they make a selection
//define a GetCost() method that calculates returns the arrow price in the Arrow class 


//this is a modified version of the level 20 implementation following more of the tips given in the book about encapsulation
//now we add static methods to create prefab arrows. the user can pick one of the prefabs or build their own


//prices and types
//Arrowheads: Steel - 10g, Wood - 3g, Obsidian - 5g
//Fletching: Plastic - 10g, Turkey Feathers - 5g, goose feathers - 3g
//Length: shaft length 60cm to 100cm long, 0.05g per cm


Console.WriteLine("This is the Fletcher's Shop.");
Console.WriteLine("Custom arrows are sold here, by the arrow. Or you can buy one of our prefabricated house favorites.");

Arrow arrow = GetArrow();

Console.WriteLine($"Your arrows will cost {arrow.Cost} gold per arrow.");

Arrow GetArrow()
{
    Console.WriteLine("Select a type of arrow: ");
    Console.WriteLine("1. Elite Arrow - Steel head, plastic fletching, 95cm shaft.");
    Console.WriteLine("2. Beginner Arrow - Wood head, goose fletching, 75cm shaft.");
    Console.WriteLine("3. Marksman Arrow - Steel head, goose fletching, 65cm shaft.");
    Console.WriteLine("4. Custom Arrow - Build your own!");
    int choice = 0;
    while (choice < 1 || choice > 4)
    {
        Console.WriteLine("Enter a number for your desired arrow ( 1 through 4 ): ");
        choice = Convert.ToInt32(Console.ReadLine());
    }

    //the author will probably have a separate method to choose if the user will do a custom or not
    //but im just cramming the choice into this method

    switch (choice)
    {
        case 1:
            return Arrow.CreateEliteArrow();
        case 2:
            return Arrow.CreateBeginnerArrow();
        case 3:
            return Arrow.CreateMarksmanArrow();
        default:
            {
                Arrowhead arrowhead = GetArrowheadType();
                Fletching fletching = GetFletchingType();
                float length = GetLength();

                return new Arrow(arrowhead, fletching, length);
            }

    }




}



Arrowhead GetArrowheadType()
{
    Console.WriteLine("Select your desired arrowhead material:");
    Console.WriteLine("1. Steel - 10g");
    Console.WriteLine("2. Wood - 3g");
    Console.WriteLine("3. Obsidian - 5g");
    Console.WriteLine("Enter a number: ");
    //ideally do some error catching here but w/e
    int input = Convert.ToInt32(Console.ReadLine());
    return input switch
    {
        1 => Arrowhead.Steel,
        2 => Arrowhead.Wood,
        3 => Arrowhead.Obsidian,
        _ => Arrowhead.Wood
    };
}

Fletching GetFletchingType()
{
    Console.WriteLine("Select your desired fletching material:");
    Console.WriteLine("1. Plastic - 10g");
    Console.WriteLine("2. Turkey Feathers - 5g");
    Console.WriteLine("3. Goose Feathers - 3g");
    Console.WriteLine("Enter a number: ");
    int input = Convert.ToInt32(Console.ReadLine());
    return input switch
    {
        1 => Fletching.Plastic,
        2 => Fletching.Turkey,
        3 => Fletching.Goose,
        _ => Fletching.Goose
    };
}


float GetLength()
{
    float length = 0;
    while (length < 60 || length > 100)
    {
        Console.WriteLine("Enter your desired shaft length between 60cm and 100cm (0.05g per cm): ");
        length = (float)Convert.ToDouble(Console.ReadLine());
    }
    return length;

}





class Arrow
{
    public Arrowhead ArrowheadType { get; } = Arrowhead.Wood;
    public Fletching FletchingType { get; } = Fletching.Goose;
    public float Length { get; } = 60f;


    //constructor for options
    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        ArrowheadType = arrowhead;
        FletchingType = fletching;
        Length = length;
    }
    
    //static 'Factory' methods
    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.Goose, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.Goose, 65);

    public float Cost
    {
        get
        {
            float headCost = ArrowheadType switch
            {
                Arrowhead.Steel => 10.0f,
                Arrowhead.Wood => 3.0f,
                Arrowhead.Obsidian => 5.0f,
                _ => 3.0f
            };

            float fletchCost = FletchingType switch
            {
                Fletching.Plastic => 10.0f,
                Fletching.Turkey => 5.0f,
                Fletching.Goose => 3.0f,
                _ => 3.0f
            };

            float shaftCost = 0.05f * Length;


            return (headCost + fletchCost + shaftCost);
        }

    }



}



//enum definition for part types
public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, Turkey, Goose }