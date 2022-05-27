// See https://aka.ms/new-console-template for more information

/*
 * This is a game combining a bunch of the previous level's programs
 * in essence this is a two player guessing game with a timer and a verbose printout display
 * 
 * Objectives:
 * Establish the game's starting state.
 * The manticore (player 1) starts with 10 health
 * the city (player 2) starts with 15 health
 * the game starts at round 1.
 * 
 * ask player 1 to set a distance (an int between 0-100) from the city.
 * clear the screen
 * 
 * run the game in a loop until either the manticore or city's health reaches 0
 * 
 * before player 2's turn, display the round number, the city's health and the manticore's health
 * 
 * using the magic cannon program, compute how much damage player 2 will do if they can successfully guess
 * where player 1 is. Display this to the player.
 * 
 * get the target range (guess) from player 2, resolve if they are right or wrong. (this is also a previous program)
 * reduce the manticore's health by the cannon's damage value if there was a hit
 * 
 * if the manticore is still alive, reduce the city's health by 1.
 * 
 * advance to the next round
 * 
 * when the manticore or the city's health reaches 0, end the game and display the outcome.
 * 
 * use different colors for different types of messages.
 * 
 */

Console.Title = "Hunting The Manticore";

//initialize global game variables
int manticoreHealth = 10;
int cityHealth = 15;
int round = 1;


//Begin Player 1's turn
//the manticore picks a position for the duration of the game
Console.WriteLine("Player 1, you command the Manticore, the dread airship of The Uncoded One's vast army.");
Console.WriteLine("Your mission is to bombard the City of Consolas from a distance.");
Console.WriteLine("Your orders are to maintain a selected distance from the city until bombardment is complete.");
Console.WriteLine("Enter a distance (a whole number from 0-100): ");
//ideally we clamp this and only take valid guesses but Im lazy rn
//p1 can just cheat and say 101
int manticorePosition = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Position acknowledged. Commencing bombardment.");
Console.Clear();



//Begin Player 2's turn
Console.WriteLine("Player 2, you are defending the City of Consolas.");
Console.WriteLine("On the horizon, you spot The Manticore, the dread airship of The Uncoded One's vast army.");
Console.WriteLine("Using the Programmer's Magic Cannon, shoot down The Manticore before it levels the city!");
Console.WriteLine("You must dial in the correct range for your shots, but you must hurry, the walls wont last long!");



//all game logic happens until the manticore or the city's health reaches 0.
while(manticoreHealth > 0 && cityHealth > 0)
{
    //write out display
    //calculate potential cannon damage
    int player2Damage = MagicCannonDamage(round);

    Console.WriteLine("---------------------------------------------------------------------------------------------------");
    Console.WriteLine($"CITY STATUS:  Round: {round}  City Health: {cityHealth}/15  Manticore Health: {manticoreHealth}/10");
    Console.WriteLine($"The cannon is expected to deal {player2Damage} damage this round if you can hit The Manticore.");

    //take a guess and check if it's hit. If it is, apply damage to the manticore
    //if the guess is a miss, damage the city
    //this prevents a simultaneous knock out, the ship cant do damage if it gets hit
    if (IsManticoreHit(manticorePosition)) manticoreHealth -= player2Damage;
    else cityHealth -= 1;

    //advance the round
    round++;

}

//The game is over, display results.
if(manticoreHealth <= 0)
{
    Console.WriteLine("We did it! The Manticore has been shot down!");
    Console.WriteLine("You saved the City of Consolas. The people are in your debt.");
}
else
{
    Console.WriteLine("The City has been destroyed...");
    Console.WriteLine("We must evacuate whoever is left...");
}






//Methods
//-----------------------------------------------------------------------------------------------------------------------------------------------------------

int MagicCannonDamage (int round)
{
    if (round % 3 == 0 && round % 5 == 0) return 10;
    else if (round % 3 == 0) return 3;
    else if (round % 5 == 0) return 5;
    else return 1;
}

bool IsManticoreHit(int manticorePosition)
{
    int guess;

    //ask for a user guess, between 0 and 100, clamp ranges and keep asking until a valid guess is made
    //if the guess is wrong, indicate if it was too high or too low. return false since no hit was made.
    //if the guess is right, indicate it was a direct hit. return true since the manticore is hit

    while (true)
    {
        Console.WriteLine("Enter a cannon range (enter a whole number between 0 and 100): ");
        guess = Convert.ToInt32(Console.ReadLine());
        if(guess >= 0 && guess <= 100)
        {
            //guess is valid, evaluate guess and return result

            if(guess < manticorePosition)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("WE MISSED! The shot fell SHORT! Increase targeting distance!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else if(guess > manticorePosition)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("WE MISSED! We OVERSHOT the target! Decrease targeting distance!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("DIRECT HIT! STAY ON TARGET!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
        }
        else
        {
            //improper guess, keep looping
            Console.WriteLine("That range isn't possible! Try again!");
        }
    }


}