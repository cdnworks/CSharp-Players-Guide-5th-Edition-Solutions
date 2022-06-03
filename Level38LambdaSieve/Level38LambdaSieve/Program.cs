/* This is a quick modification of my implementation of Level 36, The Sieve, where here I use lambda expressions
 * instead of named functions for the constructor's required filter delegate.
 * 
 */


// Main

Console.WriteLine("Choose a filter: ");
Console.WriteLine("1: Even numbers return true");
Console.WriteLine("2: Odd numbers return true");
Console.WriteLine("3: Numbers divisible by 10 return true");

int choice;
//collect valid user input for filter
while (true)
{
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice >= 1 && choice <= 3) break;
    else
    {
    Console.WriteLine($"{choice} isn't a valid choice. Enter a number, 1 through 3.");
    }
}

//create a Sieve instance and pass in the chosen filter method

//But this time, use lambda expressions for each filter instead of named methods
Sieve sieve = choice switch
{
1 => new Sieve(n => n % 2 == 0),
2 => new Sieve(n => n % 2 != 0),
3 => new Sieve(n => n % 10 == 0)
};



//let the user throw numbers into the sieve
while (true)
{
    bool result;
    Console.Write("Enter a number to filter: ");
    result = sieve.IsGood(Convert.ToInt32(Console.ReadLine()));
    Console.WriteLine($"Was your number Good? {result} \n");
}



// Type Defs
public class Sieve
{
    private Func<int, bool> _filter { get; }

    public Sieve(Func<int, bool> filterFunction)
    {
        _filter = filterFunction;
    }


    public bool IsGood(int number)
    {
        return _filter(number);
    }


}