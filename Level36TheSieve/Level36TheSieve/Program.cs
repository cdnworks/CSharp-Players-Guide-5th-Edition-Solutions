/* this program demonstrates a basic use of delegates.
 * 
 * Objectives: 
 * Create a Sieve class with a public bool IsGood(int number) method.
 * This class needs a constructor with a delegate parameter that can be invoked later within the IsGood method.
 * Hint: you can make your own delegate type or use Func<int,bool>
 * 
 * Define methods with an int parameter and a bool return type for the following:
 * 1) returns true for even numbers
 * 2) returns true for positive numbers
 * 3) returns true for multiples of 10
 * 
 * Create a program that asks the user to pick one of those 3 filters
 * then constructs a new Sieve instance by passing in one of those methods as a parameter,
 * then ask the user to enter numbers repeatedly, displaying if the number is good or bad
 * depending on the filter in use
 * 
 * Anser the following: Describe how you could have also solved this problem with inheritance and polymorphism.
 * Which solution seems more straightforward to you, and why?
 * 
 */


// Main

Console.WriteLine("Choose a filter: ");
Console.WriteLine("1: Even numbers return true");
Console.WriteLine("2: Odd numbers return true");
Console.WriteLine("3: Numbers divisible by 10 return true");

int choice;
//collect valid user input for filter
while(true)
{
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice >= 1 && choice <= 3) break;
    else
    {
        Console.WriteLine($"{choice} isn't a valid choice. Enter a number, 1 through 3.");
    }
}

//create a Sieve instance and pass in the chosen filter method
Sieve sieve = choice switch
{
    1 => new Sieve(EvenFilter),
    2 => new Sieve(OddFilter),
    3 => new Sieve(DivisibleByTenFilter)
};



//let the user throw numbers into the sieve
while(true)
{
    bool result;
    Console.Write("Enter a number to filter: ");
    result = sieve.IsGood(Convert.ToInt32(Console.ReadLine()));
    Console.WriteLine($"Was your number Good? {result} \n");
}








// Methods for main

bool EvenFilter(int number) => number % 2 == 0;

bool OddFilter(int number) => number % 2 != 0;

bool DivisibleByTenFilter(int number) => number % 10 == 0;



// Type Defs
public class Sieve
{
    private Func<int,bool> _filter { get; }

    public Sieve(Func<int, bool> filterFunction)
    {
        _filter = filterFunction;
    }


    public bool IsGood(int number)
    {
        return _filter(number);
    }


}