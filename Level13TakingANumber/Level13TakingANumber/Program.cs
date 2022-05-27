// See https://aka.ms/new-console-template for more information



/* create two methods
 * one with the signature int AskForNumber(string text)
 * display the text param and get a response from the user,
 * return the respons as an int
 * 
 * the other with the signature int AskForNumberInRange(string text, int min, int max)
 * this will ask a user to enter a value, convert said value to an int and return it if it
 * is between the min and max, otherwise it will ask the user again
 */

int result1, result2;

result1 = AskForNumber("Enter a number: ");

Console.WriteLine();

result2 = AskForNumberInRange("Enter a number: ", 1, 100);



Console.WriteLine($"Method 1 returned {result1}");
Console.WriteLine($"Method 2 returned {result2}");




int AskForNumber(string text)
{
    Console.WriteLine(text);
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}



int AskForNumberInRange(string text, int min, int max)
{
    while(true)
    {
        Console.WriteLine(text);
        int num = Convert.ToInt32(Console.ReadLine());
        if (num > min && num < max) return num;
        else Console.WriteLine($"Number outside of range of {min} and {max}, try again.");
    }


}