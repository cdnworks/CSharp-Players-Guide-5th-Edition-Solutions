/* This program is a demonstration of basic file access in C#
 * 
 * Objectives:
 * When the program starts, ask the user to enter their name.
 * 
 * By default, the player starts with a score of 0.
 * 
 * Add 1 point to their score for every keypress they make.
 * 
 * Display the player's updated score after each keypress.
 * 
 * When the player presses the Enter key, end the game. (Hint: the following code reads a keypress and checks
 * if it was the enter key: Console.ReadKey().Key == ConsoleKey.Enter )
 * 
 * When the player presses enter, save their score in a file. ( Hint: Consider saving this to a file named
 * [username].txt. For this challenge, you can assume the user doesn't enter a name that would produce an illegal file name )
 * 
 * When a user enters a name at the start, if they already have a previously saved score, start with that score instead.
 * 
 */



Console.Write("Enter your name: ");
string? userName = Console.ReadLine();

int score = 0;

// check if this player played before (meaning there is a [userName].txt file
if (File.Exists(userName + ".txt"))
{
    score = Convert.ToInt32(File.ReadAllText(userName + ".txt"));
    Console.WriteLine($"Welcome back {userName}, your score from last time was {score}, continue scoiring points!");
}


while(true)
{
    //get the key press from the user
    ConsoleKey keyPress = Console.ReadKey().Key;
    //check if it was enter, if it is, end the game
    if (keyPress == ConsoleKey.Enter) break;

    score++;
    Console.WriteLine($" Current Score: {score}");
}

//write score to file
File.WriteAllText(userName + ".txt", score.ToString());

