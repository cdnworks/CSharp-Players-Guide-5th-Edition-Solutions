// See https://aka.ms/new-console-template for more information
//this is fizzbuzz with the serial numbers filed off.
//iterate a loop 100 times, during this 
//print Fire every iteration that's a multiple of 3
//print Electric every iteration that's a multiple of 5
//Print Fire & Electric every iteration that's a multiple of 3 and 5
//print normal for all other iterations
//change the color of the console output for fire/electric/combined results
Console.WriteLine("Magic Cannon Firing Pattern Program");

//normally I'd start from 0, but Im just gonna be lazy and use the value of i as it is
//for all my calculations, so I dont wanna write i+1
for(int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(i + ": ELECTRIC & FIRE");
    }
    else if (i % 3 == 0)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(i + ": FIRE");
    }
    else if (i % 5 == 0)
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(i + ": ELECTRIC");
    }
    else { 
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(i + ": Normal");
    }


}
