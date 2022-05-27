// See https://aka.ms/new-console-template for more information


//this program takes a user input for different types of arrows,
//their choices include the arrow head type, the fletching type and a length for the arrow shaft
//each type and length incurrs a different cost, and should be displayed to the user after they make a selection
//define a GetCost() method that calculates returns the arrow price in the Arrow class 

//prices and types
//Arrowheads: Steel - 10g, Wood - 3g, Obsidian - 5g
//Fletching: Plastic - 10g, Turkey Feathers - 5g, goose feathers - 3g
//Length: shaft length 60cm to 100cm long, 0.05g per cm


Console.WriteLine("This is the Fletcher's Shop.");
Console.WriteLine("Custom arrows are sold here, by the arrow.");
Console.WriteLine("Select your desired arrowhead material:");
Console.WriteLine("1. Steel - 10g");
Console.WriteLine("2. Wood - 3g");
Console.WriteLine("3. Obsidian - 5g");
Console.WriteLine("Enter a number: ");
//ideally do some error catching here but w/e
int headChoice = Convert.ToInt32(Console.ReadLine());


Console.WriteLine("Select your desired fletching material:");
Console.WriteLine("1. Plastic - 10g");
Console.WriteLine("2. Turkey Feathers - 5g");
Console.WriteLine("3. Goose Feathers - 3g");
Console.WriteLine("Enter a number: ");
int fletchChoice = Convert.ToInt32(Console.ReadLine());


Console.WriteLine("Enter your desired shaft length in cm (0.05g per cm): ");
int shaftChoice = Convert.ToInt32(Console.ReadLine());

Arrow arrow = new Arrow(headChoice, fletchChoice, shaftChoice);

Console.WriteLine($"Your arrows will cost {arrow.GetCost()} gold per arrow.");






class Arrow
{
    //set the default fields to the cheapest option
    public Arrowhead _head = Arrowhead.Wood;
    public Fletching _fletch = Fletching.Goose;
    public int _shaftLength = 60;

    //constructor for options
    public Arrow(int arrowChoice, int fletchingChoice, int shaftChoice)
    {
        _head = arrowChoice switch
        {
            1 => Arrowhead.Steel,
            2 => Arrowhead.Wood,
            3 => Arrowhead.Obsidian,
            _ => Arrowhead.Wood
        };

        _fletch = fletchingChoice switch
        {
            1 => Fletching.Plastic,
            2 => Fletching.Turkey,
            3 => Fletching.Goose,
            _ => Fletching.Goose
        };

        _shaftLength = shaftChoice;
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

        shaftCost = 0.05f * _shaftLength;


        return (headCost + fletchCost + shaftCost);
    }


}



//enum definition for part types
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, Turkey, Goose }