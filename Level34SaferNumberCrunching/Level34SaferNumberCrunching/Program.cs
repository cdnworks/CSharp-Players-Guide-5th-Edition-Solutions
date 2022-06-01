/*
 * Create a program that asks the user for an int value. Use the static int.TryParse(string s, out int result) method
 * to parse the number. Loop until they enter a valid value.
 * 
 * Extend the program to do the same for both double and bool
 */

int number;
while (true)
{
    Console.Write("Enter an integer number: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out number) == true)
    {
        Console.WriteLine(number);
        break;
    }
}

double number2;
while (true)
{
    Console.Write("Enter a decimal number: ");
    string? input = Console.ReadLine();
    if (double.TryParse(input, out number2) == true)
    {
        Console.WriteLine(number2);
        break;
    }
}

bool truthValue;
while (true)
{
    Console.Write("Write true or false: ");
    string? input = Console.ReadLine();
    if (bool.TryParse(input, out truthValue) == true)
    {
        Console.WriteLine(truthValue);
        break;
    }
}