// See https://aka.ms/new-console-template for more information

/*
 * This is a modified version of Level 14's Hunting The Manticore
 * Where we turn the game into a single player experience by replacing the first player's turn with
 * a randomly selected location.
 * 
 */

Console.Title = "Hunting The Manticore";

//initialize global game variables
int manticoreHealth = 10;
int cityHealth = 15;
int round = 1;



//Randomly picks a position for the manticore, for the duration of the game
int manticorePosition = new Random().Next(100) + 1;



//Begin Player's turn
Console.WriteLine("Player, you are defending the City of Consolas.");
Console.WriteLine("On the horizon, you spot The Manticore, the dread airship of The Uncoded One's vast army.");
Console.WriteLine("Using the Programmer's Magic Cannon, shoot down The Manticore before it levels the city!");
Console.WriteLine("You must dial in the correct range for your shots, but you must hurry, the walls wont last long!");



//all game logic happens until the manticore or the city's health reaches 0.
while (manticoreHealth > 0 && cityHealth > 0)
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
if (manticoreHealth <= 0)
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

int MagicCannonDamage(int round)
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
        if (guess >= 0 && guess <= 100)
        {
            //guess is valid, evaluate guess and return result

            if (guess < manticorePosition)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("WE MISSED! The shot fell SHORT! Increase targeting distance!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else if (guess > manticorePosition)
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