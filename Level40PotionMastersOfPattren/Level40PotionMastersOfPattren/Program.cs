/* this is a program demonstrating different pattern matching 
 * 
 * Potions are mixed by adding one ingredient at a time until they produce a valuable potion type.
 * All potions start as water.
 * Adding stardust to water turns it into an elixir.
 * Adding snake venom to an elixir turns it into a poision potion.
 * Adding Dragon breath to an elixir turns it into a flying potion.
 * Adding shadow glass to an elixir turns it into an invisibility potion.
 * Adding an eyeshine gem to an elixir turns it into a night sight potion.
 * Adding shadow glass to a night sight potion turns it into a cloudy brew.
 * Adding an eyeshine gem to an invisibility potion turns it into a cloudy brew.
 * Adding stardust to a cloudy brew turns it into a wraith potion.
 * Anything else results in a ruined potion.
 * 
 * Objectives:
 * 
 * Create enumerations for the potion and ingredient types.
 * 
 * Tell the user what type of potion they currently have and what ingredient choices are available.
 * 
 * Allow them to enter an ingredient choice. Use a pattern to turn the user's response into an ingredient.
 * 
 * Change the current potion type according to the rules above using a pattern.
 * 
 * Allow them to choose wether to complete the potion or continue before adding an ingredient.
 * If the user decides to complete the potion, end the program.
 * 
 * When the user creates a ruined potion, tell them and start over with water.
 * 
 */


// Main
// initialize the potion as water.
PotionType potion = PotionType.Water;
while (true)
{
    Console.WriteLine($"You currently have a potion of {potion}.");
    Console.WriteLine("Add more ingredients? (enter 'no' without quotes to quit) ");
    string? input = Console.ReadLine();
    if (input == "no" || input == "No" || input == "NO") break;

    //otherwise assume they meant yes
    Console.WriteLine("You may add one of the following: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");
    Console.WriteLine("Add which ingredient: ");
    string? ingredientChoice = Console.ReadLine();

    Ingredient ingredient = ingredientChoice switch
    {
        "stardust"      => Ingredient.Stardust,
        "snake venom"   => Ingredient.SnakeVenom,
        "dragon breath" => Ingredient.DragonBreath,
        "shadow glass"  => Ingredient.ShadowGlass,
        "eyeshine gem"  => Ingredient.EyeshineGem,
        _               => Ingredient.Nothing
    };



    potion = (potion, ingredient) switch
    {
        (PotionType.Water,        Ingredient.Stardust)      => PotionType.Elixir,
        (PotionType.Elixir,       Ingredient.SnakeVenom)    => PotionType.Poison,
        (PotionType.Elixir,       Ingredient.DragonBreath)  => PotionType.Flying,
        (PotionType.Elixir,       Ingredient.ShadowGlass)   => PotionType.Invisibility,
        (PotionType.Elixir,       Ingredient.EyeshineGem)   => PotionType.Nightsight,
        (PotionType.Nightsight,   Ingredient.ShadowGlass)   => PotionType.Cloudybrew,
        (PotionType.Invisibility, Ingredient.EyeshineGem)   => PotionType.Cloudybrew,
        (PotionType.Cloudybrew,   Ingredient.Stardust)      => PotionType.Wraith,

        //adding nothing to any potion type will not change it!
        (_,                       Ingredient.Nothing)       => potion,
        //any other combination ruins the potion.
        (_,                       _)                        => PotionType.Ruined
    };

    if(potion == PotionType.Ruined)
    {
        Console.WriteLine("Whoops, you ruined the potion! Lets try again with some fresh water.");
        potion = PotionType.Water;
    }


}





// Enums
public enum PotionType { Water, Elixir, Poison, Flying, Invisibility, Nightsight, Cloudybrew, Wraith, Ruined}
public enum Ingredient { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem, Nothing}