// See https://aka.ms/new-console-template for more information

/* define enumerations for 3 types of food, main ingredients and seasoning
 * 
 * make a tuple variable that contains one of each of the 3 enumeration types
 * 
 * let the user pick the food type, main ingredient and seasoning to give value to the tuple.
 * 
 * when done display the completed 'dish' touple in a readable format ({spice},{ingredient},{soup type})
 * 
 */

//build tuple
(SoupType soup, Seasoning spice, Ingredient ingredient) soup = MakeSoup();
//print out soup
Console.WriteLine($"{soup.spice} {soup.ingredient} {soup.soup}");




(SoupType, Seasoning, Ingredient) MakeSoup()
{
    SoupType type = GetSoupType();
    Seasoning spice = GetSeasoning();
    Ingredient ingredient = GetIngredient();
    return (type, spice, ingredient);
}


SoupType GetSoupType()
{
    Console.WriteLine("What kind of soup do you want:");
    while (true)
    {
        Console.WriteLine("1. Soup");
        Console.WriteLine("2. Stew");
        Console.WriteLine("3. Gumbo");
        Console.WriteLine("Enter a number to select:");
        int soupSelection = Convert.ToInt32(Console.ReadLine());
        if (soupSelection == 1) return SoupType.Soup;
        if (soupSelection == 2) return SoupType.Stew;
        if (soupSelection == 3) return SoupType.Gumbo;
        else Console.WriteLine("Invalid Selection. Enter 1, 2 or 3.");
    }
}

Seasoning GetSeasoning()
{
    Console.WriteLine("What kind of seasoning do you want:");
    while (true)
    {
        Console.WriteLine("1. Spicy");
        Console.WriteLine("2. Salty");
        Console.WriteLine("3. Sweet");
        Console.WriteLine("Enter a number to select:");
        int soupSelection = Convert.ToInt32(Console.ReadLine());
        if (soupSelection == 1) return Seasoning.Spicy;
        if (soupSelection == 2) return Seasoning.Salty;
        if (soupSelection == 3) return Seasoning.Sweet;
        else Console.WriteLine("Invalid Selection. Enter 1, 2 or 3.");
    }
}


Ingredient GetIngredient()
{
    Console.WriteLine("What kind of seasoning do you want:");
    while (true)
    {
        Console.WriteLine("1. Mushrooms");
        Console.WriteLine("2. Chicken");
        Console.WriteLine("3. Carrots");
        Console.WriteLine("4. Potatoes");
        Console.WriteLine("Enter a number to select:");
        int soupSelection = Convert.ToInt32(Console.ReadLine());
        if (soupSelection == 1) return Ingredient.Mushroom;
        if (soupSelection == 2) return Ingredient.Chicken;
        if (soupSelection == 3) return Ingredient.Carrot;
        if (soupSelection == 4) return Ingredient.Potato;
        else Console.WriteLine("Invalid Selection. Enter 1, 2, 3 or 4.");
    }
}




enum SoupType {Soup, Stew, Gumbo};
enum Seasoning {Spicy, Salty, Sweet};
enum Ingredient {Mushroom, Chicken, Carrot, Potato};





