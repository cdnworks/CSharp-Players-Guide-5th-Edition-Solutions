/* This program is for demonstrating the use of exceptions
 * 
 * This is a simple game of number guessing between two players.
 * The computer first selects a number between 0 and 9 at random
 * Two players take turns guessing a number between 0 and 9
 * The first player to guess the same number as the computer's chosen number, loses.
 * 
 * but they dont just lose, the program throws an exception and crashes!
 * 
 * players may not repeat guesses. So keep track of that too.
 * 
 */

//set the game up
Random random = new Random();
List<int> guesses = new List<int> { };
int evilNumber = random.Next(10);
int guess;

//game loop goes until the program crashes
while(true)
{
    //collect user input

    try
    {
        while (true)
        {
            Console.Write("Take a guess between 0 and 9: ");
            guess = Convert.ToInt32(Console.ReadLine());
            if (guess >= 0 && guess <= 9 && !guesses.Contains(guess)) break;
            else Console.WriteLine($"{guess} isnt valid, jackass.");
        }

        if (guess == evilNumber) {
            Exception e = new Exception("The bad number!");
            throw e;
        }
        else guesses.Add(guess);
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }



}


