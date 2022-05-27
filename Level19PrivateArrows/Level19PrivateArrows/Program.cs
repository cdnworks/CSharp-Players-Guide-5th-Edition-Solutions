// See https://aka.ms/new-console-template for more information


//this program takes a user input for different types of arrows,
//their choices include the arrow head type, the fletching type and a length for the arrow shaft
//each type and length incurrs a different cost, and should be displayed to the user after they make a selection
//define a GetCost() method that calculates returns the arrow price in the Arrow class 


//this is a modified version of the level 18 implementation following more of the tips given in the book about encapsulation
//it privatizes fields in the arrow class and adds some getter methods for the arrow properities.


//prices and types
//Arrowheads: Steel - 10g, Wood - 3g, Obsidian - 5g
//Fletching: Plastic - 10g, Turkey Feathers - 5g, goose feathers - 3g
//Length: shaft length 60cm to 100cm long, 0.05g per cm


Console.WriteLine("This is the Fletcher's Shop.");
Console.WriteLine("Custom arrows are sold here, by the arrow.");

Arrow arrow = GetArrow();

Console.WriteLine($"Your arrows will cost {arrow.GetCost()} gold per arrow.");

Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
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
    //set the default fields to the cheapest option
    private Arrowhead _head = Arrowhead.Wood;
    private Fletching _fletch = Fletching.Goose;
    private float _length = 60;

    //get methods
    public Arrowhead GetArrowhead() => _head;
    public Fletching GetFletching() => _fletch;
    public float GetLength() => _length;


    //constructor for options
    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _head = arrowhead;
        _fletch = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float headCost, fletchCost, shaftCost;
        headCost = _head switch
        {
            Arrowhead.Steel => 10.0f,
            Arrowhead.Wood => 3.0f,
            Arrowhead.Obsidian => 5.0f,
            _ => 3.0f
        };

        fletchCost = _fletch switch
        {
            Fletching.Plastic => 10.0f,
            Fletching.Turkey => 5.0f,
            Fletching.Goose => 3.0f,
            _ => 3.0f
        };

        shaftCost = 0.05f * _length;


        return (headCost + fletchCost + shaftCost);
    }



}



//enum definition for part types
public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, Turkey, Goose }