// See https://aka.ms/new-console-template for more information

//given a list of items,
//take a user's name and selection
//then display the associated price of the thing
//if the user name = the special name, the price  = price * 0.5

//items and prices
// rope - 10g
// torches - 15g
// climbing gear - 25g
// Water - 1g
// machete - 20g
// canoe - 200g
// food - 1g

string specialName = "Fart";
double priceMod = 1;

Console.WriteLine("whats ur name dummy?");
string name = Console.ReadLine();

//set price modifier, if name = special name, price mod = 0.5 (50% off)
if (name == specialName) priceMod = 0.5;

Console.WriteLine("These are the things i got, " + name);
Console.WriteLine("1. rope");
Console.WriteLine("2. torches");
Console.WriteLine("3. climbing gear");
Console.WriteLine("4. water");
Console.WriteLine("5. machete");
Console.WriteLine("6. canoe");
Console.WriteLine("7. food");
Console.WriteLine("Select the thing u want (enter the number): ");

int choice = Convert.ToInt32(Console.ReadLine());

string response = choice switch
{
    1 => $"rope is {(10*priceMod)}",
    2 => "torches' " + (15 * priceMod),
    3 => "climbing gear's " + (25 * priceMod),
    4 => "water's " + (1 * priceMod),
    5 => "machete's " + (20 * priceMod),
    6 => "big spender, canoe's " + (200 * priceMod),
    7 => "food's " + (1 * priceMod),
    _ => "I dont know what you want"
};

Console.WriteLine("Well, " + name + ", " + response);

