// See https://aka.ms/new-console-template for more information

//this is basically a two player number guess game
//player 1 enters some number from 0-100
//console screen clears
//player 2 keeps guessing until they find p1's guess
//the game will hint if p2 is guessing too low or too high

//sidenote:
//there is no clamping for our guesses here, I just want to bang out these early problems
//though I still would like to keep track of what I'd really be trying to do IRL

Console.WriteLine("Pilot, enter your position (a whole number from 0-100)");
int pilotNumber = Convert.ToInt32(Console.ReadLine());
//clear screen for player 2
Console.Clear();

Console.WriteLine("Tracker, enter your guess (a whole number from 0-100)");
int guess = Convert.ToInt32(Console.ReadLine());

while (guess != pilotNumber)
{
    Console.WriteLine("Incorrect position, the airship isn't there!");
    if (guess > pilotNumber) Console.WriteLine("Your guess of " + guess + " was too large!");
    if (guess < pilotNumber) Console.WriteLine("Your guess of " + guess + " was too small!");

    Console.WriteLine("Tracker, enter another guess (a whole number from 0-100)");
    guess = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Target Aquired! Airship was at " + pilotNumber);
Console.WriteLine("Your guess at " + guess + " was correct!");
